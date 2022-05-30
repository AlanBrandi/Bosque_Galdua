using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    SettingsPanel settingsPanel;
    Scene sceneName;
    readonly string tutorial = "Tutorial";
    void Awake()
    {
        settingsPanel = GameObject.FindObjectOfType<SettingsPanel>();
        sceneName = SceneManager.GetActiveScene();
        settingsPanel.slider[0].value = PlayerPrefs.GetFloat("MasterVol", 1);
        settingsPanel.slider[1].value = PlayerPrefs.GetFloat("MusicVol", 1);
        settingsPanel.slider[2].value = PlayerPrefs.GetFloat("SFXVol", 1);
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 0;
    }
    private void Start()
    {
        GameManager.Instance.SetLife(GameManager.Instance.playerLives.lives);
        if (sceneName.name == tutorial)
        {
            GameManager.Instance.SetLife(6);
        }
    }
}