using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject GameCompletedCanvas;
    [HideInInspector] public bool isClickable = true;
    [HideInInspector] public bool isGameCompleted = false;

    public static LevelManager instance;

    public GameObject selectionHolder, blocks;

    private bool tryCheck;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(selectionHolder.transform.childCount == 3)
        {
            if (!tryCheck)
            {
                tryCheck = true;
                isClickable = false;
                StartCoroutine(CheckBlocks());
            }
        }

        if(blocks.transform.childCount == 0)
        {
            if(!isGameCompleted)
            {
                isGameCompleted = true;
                StartCoroutine(GameCompleted());
            }
        }
    }

    IEnumerator GameCompleted()
    {
        yield return new WaitForSeconds(1f);
        GameCompletedCanvas.SetActive(true);
    }

    public IEnumerator CheckBlocks()
    {
        yield return new WaitForSeconds(1.5f);
        if( selectionHolder.transform.GetChild(0).gameObject.tag == selectionHolder.transform.GetChild(1).gameObject.tag &&
            selectionHolder.transform.GetChild(0).gameObject.tag == selectionHolder.transform.GetChild(2).gameObject.tag)
        {
            Debug.Log("3 Match");
            for(int i = 0; i < selectionHolder.transform.childCount; i++)
            {
                Destroy(selectionHolder.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                selectionHolder.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<BlockAnimCtrl>().HideBlock();
                selectionHolder.transform.GetChild(0).gameObject.transform.parent = blocks.transform;
            }
        }
        tryCheck = false;
        isClickable = true;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
