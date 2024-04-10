using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimCtrl : MonoBehaviour
{
    [SerializeField] Animator blockAnim;

    private void OnMouseDown()
    {
        blockAnim.SetInteger("BlockShow", 1);
    }
}
