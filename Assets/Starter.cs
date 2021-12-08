using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    public GameData_SO gameData;
    public SettingsPanel settingsPanel;
    Scene sceneName;
    readonly string forest = "Forest";
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
    private void Start()
    {
        settingsPanel.slider[0].value = PlayerPrefs.GetFloat("MasterVol", 1);
        settingsPanel.slider[1].value = PlayerPrefs.GetFloat("MusicVol", 1);
        settingsPanel.slider[2].value = PlayerPrefs.GetFloat("SFXVol", 1);
    }
}