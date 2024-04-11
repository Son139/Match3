using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockAnimCtrl : MonoBehaviour
{
    [SerializeField] Animator blockAnim;

    private GridLayoutGroup gridLayoutGroup;
    private Vector3[] objectPositions;
    private bool isGridLayoutActive = true;


    private void OnMouseDown()
    {
        if (LevelManager.instance.isClickable)
        {
            Debug.Log(transform.parent.gameObject.transform.parent);
            //transform.parent.gameObject.transform.parent = LevelManager.instance.selectionHolder.transform;
            transform.parent.SetParent(LevelManager.instance.selectionHolder.transform);
            blockAnim.SetInteger("BlockShow", 1);
        }
    }

    public void HideBlock()
    {
        blockAnim.SetInteger("BlockShow", 0);
    }
}
