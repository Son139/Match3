using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeGameSetting : MonoBehaviour
{
    private static ModeGameSetting instance;
    public static ModeGameSetting Instance { get => instance; }

    [SerializeField] InputField nameInput;
    [SerializeField] GameObject mode9Tile;
    [SerializeField] GameObject mode12Tile;
    [SerializeField] GameObject mode15Tile;

    private int numberOfTiles;
    private void Awake()
    {
        nameInput.text = "";
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadMode9Tile()
    {
        numberOfTiles = 9;
        StartCoroutine(DelayedLoadScene("GamePlay"));
    }

    public void LoadMode12Tile()
    {
        numberOfTiles = 12;
        StartCoroutine(DelayedLoadScene("GamePlay"));
    }

    public void LoadMode15Tile()
    {
        numberOfTiles = 15;
        StartCoroutine(DelayedLoadScene("GamePlay"));
    }

    public int GetNumberOfTiles()
    {
        return numberOfTiles;
    }

    IEnumerator DelayedLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetString("playerName", nameInput.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }
}
