using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuGame : MonoBehaviour
{
    public float delayTime = 1f;

    public void StartGame()
    {
        StartCoroutine(DelayedLoadScene("SetGame"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackGame()
    {
        StartCoroutine(DelayedLoadScene("MainMenu"));
    }

    IEnumerator DelayedLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }
}
