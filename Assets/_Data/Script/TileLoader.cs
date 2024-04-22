using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    [SerializeField] private ModeGameSetting modeGameSetting;
    [SerializeField] private Transform tilesParent; // Tham chiếu đến GameObject Tiles

    private void Start()
    {
        LoadTiles();
    }

    private void LoadTiles()
    {
        //List<GameObject> selectedTiles = modeGameSetting.GetSelectedTiles();

        //if (selectedTiles == null || selectedTiles.Count == 0)
        //{
        //    Debug.LogError("Không có prefabs được chọn để load.");
        //    return;
        //}

        //// Instantiate và làm con của tilesParent
        //foreach (GameObject tilePrefab in selectedTiles)
        //{
        //    Instantiate(tilePrefab, tilesParent);
        //}
    }
}
