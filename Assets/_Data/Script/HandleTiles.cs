using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTiles : MonoBehaviour
{
    [SerializeField] private string prefabFolderName = "Prefabs/Blocks";
    [SerializeField] private Transform tiles;

    private List<GameObject> tilePrefabs = new();

    private void Start()
    {
        LoadTilePrefabs();
        LoadGamePlayScene(ModeGameSetting.Instance.GetNumberOfTiles());
    }

    private void LoadTilePrefabs()
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(prefabFolderName);
        tilePrefabs.AddRange(prefabs);
        Debug.Log(prefabs.Length);
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    private void LoadGamePlayScene(int numberOfTiles)
    {
        List<GameObject> shuffledPrefabs = new(tilePrefabs);
        Shuffle(shuffledPrefabs);

        List<GameObject> selectedTiles = new();
        for (int i = 0; i < numberOfTiles / 3; i++)
        {
            GameObject randomTilePrefab = shuffledPrefabs[i];
            //Debug.Log(randomTilePrefab.name+"\n");
            selectedTiles.Add(randomTilePrefab);
        }

        List<GameObject> finalTiles = new();
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject randomTilePrefab = selectedTiles[i % selectedTiles.Count];
            Debug.Log(selectedTiles.Count);
            Debug.Log(i % selectedTiles.Count);
            finalTiles.Add(randomTilePrefab);
        }

        List<GameObject> instantiatedTiles = new();
        Shuffle(finalTiles); 
        foreach (GameObject prefab in finalTiles)
        {
            GameObject instantiatedTile = Instantiate(prefab, tiles);
            instantiatedTiles.Add(instantiatedTile);
            Debug.Log(prefab.name);
        }
    }

}
