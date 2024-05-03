using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public static GameScene instance;

    [SerializeField] public GameObject gameCompletedDialog;
    [SerializeField] public GameObject selectionHolder;
    [SerializeField] GameObject tiles;
    [SerializeField] string filename;

    public bool isClickable = true;
    private bool isGameCompleted = false;
    private bool tryCheck = false;
    private int countDestroy;
    private float timePlay;

    List<PlayerData> playerDataList = new();
    private Dictionary<int, PlayerData> bestPlayersByMode = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        countDestroy = 0;
        playerDataList = FileHandler.ReadListFromJSON<PlayerData>(filename);
    }

    private void Update()
    {
        CheckSelection();
        CheckTiles();
    }

    private void LoadBestPlayersData()
    {
        foreach (PlayerData playerData in playerDataList)
        {
            if (!bestPlayersByMode.ContainsKey(playerData.modeGame) )
            {
                bestPlayersByMode[playerData.modeGame] = playerData;
            }
        }
    }

    private void CheckSelection()
    {
        if (selectionHolder.transform.childCount == 3 && !tryCheck)
        {
            tryCheck = true;
            isClickable = false;
            StartCoroutine(CheckBlocksCoroutine());
        }
    }

    IEnumerator CheckBlocksCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        if (AreBlocksMatching())
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.match3Tiles);
            DestroySelectionBlocks();
        }
        else
        {
            MoveSelectionBlocksToBlocks();
        }
        tryCheck = false;
        isClickable = true;
    }

    private bool AreBlocksMatching()
    {
        if (selectionHolder.transform.childCount == 0) return false;
        string firstTag = selectionHolder.transform.GetChild(0).gameObject.tag;

        for (int i = 1; i < 3; i++)
        {
            if (selectionHolder.transform.GetChild(i).gameObject.tag != firstTag)
            {
                return false;
            }
        }
        return true;
    }

    private void CheckTiles()
    {
        if (countDestroy == ModeGameSetting.Instance.GetNumberOfTiles() && !isGameCompleted)
        {
            isGameCompleted = true;
            StartCoroutine(GameCompletedCoroutine());
        }
    }

    public void SaveDataPlayer()
    {
        int modeGame = ModeGameSetting.Instance.GetNumberOfTiles();
        string playerName = PlayerPrefs.GetString("playerName");
        float curPlayerTime = Timer.Instance.GetTimeWhenEndGame();

        float shortestTime = float.MaxValue;
        foreach( var entry in playerDataList )
        {
            if(entry.modeGame == modeGame && entry.timePlay < shortestTime)
            {
                shortestTime = entry.timePlay;  
            }
        }

        playerDataList.RemoveAll(entry => entry.modeGame == modeGame && entry.timePlay > curPlayerTime);

        if (curPlayerTime <= shortestTime)
        {
            playerDataList.Add(new PlayerData(playerName, curPlayerTime, modeGame));
        }
        FileHandler.SaveToJSON<PlayerData>(playerDataList, filename);

    }

    IEnumerator GameCompletedCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Timer.Instance.StopTimer();
        SaveDataPlayer();
        LoadBestPlayersData();
        DisplayBestPlayer.instance.DisplayBestPlayersInfo(bestPlayersByMode);
        gameCompletedDialog.SetActive(true);
    }

    private void DestroySelectionBlocks()
    {
        for (int i = 0; i < selectionHolder.transform.childCount; i++)
        {
            Destroy(selectionHolder.transform.GetChild(i).gameObject);
        }
        countDestroy += 3;
    }

    private void MoveSelectionBlocksToBlocks()
    {
        List<Transform> parentList = new(BlockAnimCtrl.originalParents);

        for (int i = 0; i < 3; i++)
        {
            if (selectionHolder.transform.childCount == 0) return;
            Transform blockTransform = selectionHolder.transform.GetChild(0);
            blockTransform.GetChild(0).GetComponent<BlockAnimCtrl>().HideBlock();
            blockTransform.parent = parentList[i].transform;
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
