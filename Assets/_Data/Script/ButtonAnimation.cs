using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    Button btn;
    Vector3 upScale = new(1.2f, 1.2f, 1);

    private void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Anim);
    }

    void Anim()
    {
        //AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClick);

        transform.DOScale(upScale, 0.1f);
        transform.DOScale(Vector3.one, 0.1f).SetDelay(0.1f);
    }
}
