using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public static BaseScene instance;

    [SerializeField] public GameObject gameCompletedDialog;
    [SerializeField] public GameObject selectionHolder;
    [SerializeField] GameObject tiles;

    public bool isClickable = true;
    protected bool isGameCompleted = false;
    protected bool tryCheck = false;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    protected virtual void Update()
    {
        CheckSelection();
        CheckBlocks();
    }

    protected virtual void CheckSelection()
    {
        if (selectionHolder.transform.childCount == 3 && !tryCheck)
        {
            tryCheck = true;
            isClickable = false;
            StartCoroutine(CheckBlocksCoroutine());
        }
    }

    protected virtual void CheckBlocks()
    {
        if (tiles.transform.childCount == 0 && !isGameCompleted)
        {
            isGameCompleted = true;
            StartCoroutine(GameCompletedCoroutine());
        }
    }

    IEnumerator GameCompletedCoroutine()
    {
        yield return new WaitForSeconds(1f);
        gameCompletedDialog.SetActive(true);
    }

    public IEnumerator CheckBlocksCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        if (AreBlocksMatching())
        {
            DestroySelectionBlocks();
        }
        else
        {
            MoveSelectionBlocksToBlocks();
        }
        tryCheck = false;
        isClickable = true;
    }

    protected virtual bool AreBlocksMatching()
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

    protected virtual void DestroySelectionBlocks()
    {
        for (int i = 0; i < selectionHolder.transform.childCount; i++)
        {
            Destroy(selectionHolder.transform.GetChild(i).gameObject);
        }
    }

    protected virtual void MoveSelectionBlocksToBlocks()
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
