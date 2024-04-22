using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecificScene : BaseScene
{
    private int widthBoard;
    private int heightBoard;

    private Dictionary<int, Vector2Int> boardSizeMap = new()
    {
        { 9, new Vector2Int(3, 3) },
        { 12, new Vector2Int(4, 3) },
        { 15, new Vector2Int(5, 3) }
    };

    protected override void Awake()
    {

    }
    protected override void Start()
    {
        //SetBoardSize();
    }
}
