using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockAnimCtrl : MonoBehaviour
{
    [SerializeField] Animator blockAnim;

    public static List<Transform> originalParents = new();

    private void OnMouseDown()
    {
        if (BaseScene.instance.isClickable)
        {
            if (originalParents.Count == 3)
            {
                ResetOriginalParents();
            }
            originalParents.Add(transform.parent.gameObject.transform.parent);
                
            //transform.parent.gameObject.transform.parent = BaseScene.instance.selectionHolder.transform;
            transform.parent.SetParent(BaseScene.instance.selectionHolder.transform);
            blockAnim.SetInteger("BlockShow", 1);
        }
    }

    public void HideBlock()
    {
        blockAnim.SetInteger("BlockShow", 0);
    }

    private void ResetOriginalParents()
    {
        originalParents.Clear();
    }
}
