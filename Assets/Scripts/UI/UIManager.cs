using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IObserver
{
    [SerializeField]
    private GameObject _gameOver;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _settingsPanel;

    [SerializeField]
    private GameObject _pauseMenuUI;

    [SerializeField]
    private GameObject creditosPanel;

    private static bool GameIsPaused = false;
   
    private void Awake()
    {
        _gameOver = GameObject.Find("GameOver");
        _settingsPanel = GameObject.Find("SettingsPanel");
        _pauseMenuUI = GameObject.Find("PauseMenu");
        _gameOver.SetActive(false);
        _settingsPanel.SetActive(false);
        _pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        //Mudar para o novo inputSystem.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true && _settingsPanel.activeInHierarchy == false)
            {
                Resume();
            }
            else if (GameIsPaused == true && _settingsPanel.activeInHierarchy == true)
            {
                ToggleSettings();
            }
            else
            {
                Pause();
            }
        }
    }
    private void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        GameIsPaused = true;
    }
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
    }
    public void ToggleSettings()
    {
        if (_settingsPanel.activeInHierarchy == false)
        {
            _settingsPanel.SetActive(true);
        }
        else
        {
            _settingsPanel.SetActive(false);
        }
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Sair()
     { 
        Application.Quit();
     }
    public void NotifyPlayerHit(int damage)
    {

    }
}
