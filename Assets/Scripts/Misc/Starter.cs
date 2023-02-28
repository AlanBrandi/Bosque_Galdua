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
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 0;
    }
    private void Start()
    {
        settingsPanel.slider[0].GetComponent<SetVolume>().SetLevel(PlayerPrefs.GetFloat("MasterVol", 1));
        settingsPanel.slider[1].GetComponent<SetVolume>().SetLevel(PlayerPrefs.GetFloat("MusicVol", 1));
        settingsPanel.slider[2].GetComponent<SetVolume>().SetLevel(PlayerPrefs.GetFloat("SFXVol", 1));
        GameManager.Instance.SetLife(GameManager.Instance.playerLives.lives);
        if (sceneName.name == tutorial)
        {
            GameManager.Instance.SetLife(6);
        }
    }
}