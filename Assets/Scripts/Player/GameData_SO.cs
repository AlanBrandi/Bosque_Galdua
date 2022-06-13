using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData_New", menuName = "GameData")]

public class GameData_SO : ScriptableObject, ISerializationCallbackReceiver, ISaveable
{
    public int lives = 6, maxLives;

<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes
    public void OnAfterDeserialize()
    {
        lives = 6;
    }

    public void OnBeforeSerialize()
    {
    }
<<<<<<< Updated upstream
    

    
=======

    public object saveState()
    {
        return new saveData()
        {
            lives = this.lives,
            maxLives = this.maxLives
        };
    }

    public void loadState(object state)
    {
        var saveData = (saveData)state;
        lives = saveData.lives;
        maxLives = saveData.maxLives;
    }

    [SerializeField]
    private struct saveData
    {

        public int lives;
        public int maxLives;
    }
>>>>>>> Stashed changes
}
