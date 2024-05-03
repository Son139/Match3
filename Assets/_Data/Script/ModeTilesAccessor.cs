using System.Collections.Generic;
using UnityEngine;

public static class ModeTilesAccessor
{
    private static Dictionary<int, GameObject> modeTilesMap = new();

    public static void InitializeModeTiles(Dictionary<int, GameObject> tiles)
    {
        modeTilesMap = tiles;
    }

    public static GameObject GetModeTile(int mode)
    {
        if (modeTilesMap.ContainsKey(mode))
        {
            return modeTilesMap[mode];
        }
        else
        {
            Debug.LogError("Mode not found in modeTilesMap");
            return null;
        }
    }
}