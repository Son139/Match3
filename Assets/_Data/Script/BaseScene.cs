using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public static BaseScene instance;

    [SerializeField] protected GameObject gameCompletedCanvas;
    [SerializeField] public GameObject selectionHolder;
    [SerializeField] public GameObject blocks;

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
    protected virtual void Start()
    {
        
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
        if (blocks.transform.childCount == 0 && !isGameCompleted)
        {
            isGameCompleted = true;
            StartCoroutine(GameCompletedCoroutine());
        }
    }

    IEnumerator GameCompletedCoroutine()
    {
        yield return new WaitForSeconds(1f);
        gameCompletedCanvas.SetActive(true);
    }

    public IEnumerator CheckBlocksCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        if (AreBlocksMatching())
        {
            Debug.Log("3 Match");
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
        return selectionHolder.transform.GetChild(0).gameObject.tag == selectionHolder.transform.GetChild(1).gameObject.tag &&
               selectionHolder.transform.GetChild(0).gameObject.tag == selectionHolder.transform.GetChild(2).gameObject.tag;
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
        for (int i = 0; i < 3; i++)
        {
            Transform blockTransform = selectionHolder.transform.GetChild(0);
            blockTransform.GetChild(0).GetComponent<BlockAnimCtrl>().HideBlock();
            blockTransform.parent = blocks.transform;
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
