using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData_New", menuName = "GameData")]

public class GameData_SO : ScriptableObject, ISerializationCallbackReceiver
{
    
    public int livesMax { get; set; }
    public int CurrentLives { get; set; }
    public int initialLevelLives { get; set; }

    public void OnAfterDeserialize()
    {
        CurrentLives = 6;
    }
    public void OnBeforeSerialize()
    {
    }
}
