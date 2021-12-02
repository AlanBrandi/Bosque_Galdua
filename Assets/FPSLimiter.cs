using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSLimiter : MonoBehaviour
{
    public GameData_SO gameData;
    Scene sceneName;
    string forest = "Forest";
    void Awake()
    {
        sceneName = SceneManager.GetActiveScene();
        if (sceneName.name == forest)
        {
            gameData.lives = 15;
        }
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
}