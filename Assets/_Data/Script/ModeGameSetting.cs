using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeGameSetting : MonoBehaviour
{
    private static ModeGameSetting instance;
    public static ModeGameSetting Instance { get => instance; }

    [SerializeField] GameObject mode9Tile;
    [SerializeField] GameObject mode12Tile;
    [SerializeField] GameObject mode15Tile;

    private int numberOfTiles;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void LoadMode9Tile()
    {
        numberOfTiles = 9;
        SceneManager.LoadScene("GamePlay");
    }

    public void LoadMode12Tile()
    {
        numberOfTiles = 12;
        SceneManager.LoadScene("GamePlay");
    }

    public void LoadMode15Tile()
    {
        numberOfTiles = 15;
        SceneManager.LoadScene("GamePlay");
    }

    public int GetNumberOfTiles()
    {
        return numberOfTiles;
    }
}
