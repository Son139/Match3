using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimCtrl : MonoBehaviour
{
    [SerializeField] Animator blockAnim;

    private void OnMouseDown()
    {
        if (LevelManager.instance.isClickable)
        {
            transform.parent.gameObject.transform.parent = LevelManager.instance.selectionHolder.transform;
            blockAnim.SetInteger("BlockShow", 1);
        }
    }

    public void HideBlock()
    {
        blockAnim.SetInteger("BlockShow", 0);
    }
}
