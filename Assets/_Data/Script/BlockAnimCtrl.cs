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
        if (CanBlockBeClicked())
        {
            PlayBlockSound();
            MoveBlock();
        }
    }

    private bool CanBlockBeClicked()
    {
        return GameGUIController.isPause && GameScene.instance.isClickable;
    }

    private void PlayBlockSound()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.checkTile);
    }

    private void MoveBlock()
    {
        if (originalParents.Count == 3)
        {
            ResetOriginalParents();
        }
        originalParents.Add(transform.parent.gameObject.transform.parent);

        transform.parent.SetParent(GameScene.instance.selectionHolder.transform);
        blockAnim.SetInteger("BlockShow", 1);
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
