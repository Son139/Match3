using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuGame : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SetGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
