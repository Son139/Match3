using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayBestPlayer : MonoBehaviour
{
    public static DisplayBestPlayer instance;

    [SerializeField] GameObject Mode9Tiles;
    [SerializeField] GameObject Mode12Tiles;
    [SerializeField] GameObject Mode15Tiles;

    //private Dictionary<int, PlayerData> bestPlayersByMode = new();
    private Dictionary<int, GameObject> modeTilesMap = new();

    private void Awake()
    {
        InitializeModeTilesMap();
        if (instance == null)
        {
            instance = this;
        }
    }

    private void InitializeModeTilesMap()
    {
        modeTilesMap.Add(9, Mode9Tiles);
        modeTilesMap.Add(12, Mode12Tiles);
        modeTilesMap.Add(15, Mode15Tiles);
    }

    public void DisplayBestPlayersInfo(Dictionary<int, PlayerData> bestPlayersByMode)
    {
        foreach (var kvp in bestPlayersByMode)
        {
            int modeGame = kvp.Key;
            if (modeTilesMap.TryGetValue(modeGame, out GameObject selectedTiles))
            {
                DisplayPlayerInfo(selectedTiles, kvp.Value);
            }
            else
            {
                Debug.LogError("Not Found GameObject for Mode: " + modeGame);
            }
        }
    }

    private void DisplayPlayerInfo(GameObject selectedTiles, PlayerData playerData)
    {
        Transform bestTimeTransform = selectedTiles.transform.Find("BestTime");
        if (bestTimeTransform == null)
        {
            Debug.LogError("Not Found ChildGameObject 'BestTime' in selectedTiles.");
            return;
        }

        //GameObject playerNameObject = bestTimeTransform.Find("PlayerName").gameObject;
        Transform playerNameObject = bestTimeTransform.Find("PlayerName");

        if (playerNameObject != null)
        {
            TextMeshProUGUI textMeshComponent = playerNameObject.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = playerData.playerName;
        }

        Transform timePlayObject = bestTimeTransform.Find("TimeText");
        if (timePlayObject != null)
        {
            TextMeshProUGUI textMeshComponent = timePlayObject.GetComponent<TextMeshProUGUI>();
            string formattedTime = Timer.Instance.GetFormattedTime(playerData.timePlay);
            textMeshComponent.text = formattedTime;
        }
    }
}
