using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedGame : MonoBehaviour
{
    public void NextBtn()
    {
        SceneManager.LoadScene(0);
    }
}
