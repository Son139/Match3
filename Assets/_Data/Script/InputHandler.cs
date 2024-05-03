using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] string filename;

    List<PlayerData> entries = new();

    private void Awake()
    {
        nameInput.text = "";
    }

    private void Start()
    {
        entries = FileHandler.ReadListFromJSON<PlayerData>(filename);
    }

    //public void SaveModeGame()
    //{
    //    float timePlay = Timer.Instance.GetTimeWhenEndGame();
    //    entries.Add(new InputEntry(nameInput.text, timePlay));

    //    FileHandler.SaveToJSON<InputEntry>(entries, filename);
    //}
}