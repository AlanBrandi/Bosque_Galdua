using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData_New", menuName = "GameData")]

public class GameData_SO : ScriptableObject, ISerializationCallbackReceiver
{
    public int lives = 6;

    public void OnAfterDeserialize()
    {
        lives = 6;
    }

    public void OnBeforeSerialize()
    {
    }
}
