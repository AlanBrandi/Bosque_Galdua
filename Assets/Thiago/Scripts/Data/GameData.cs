using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lives;
    public Vector3 playerPosition;

    public GameData()
    {
        this.lives = 6;
        this.playerPosition = Vector3.zero;
    }
    
}
