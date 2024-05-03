using System;

[Serializable]
public class PlayerData
{
    public string playerName;
    public float timePlay;
    public int modeGame;

    public PlayerData(string name, float timePlay, int modeGame)
    {
        playerName = name;
        this.timePlay = timePlay;
        this.modeGame = modeGame;
    }
}