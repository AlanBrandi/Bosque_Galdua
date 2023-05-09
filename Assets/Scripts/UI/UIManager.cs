using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IObserver
{
    private GameObject _settingsPanel;
    private GameObject _gameOver;
    private GameObject _pauseMenuUI;
    private GameObject _lowLife;

 
    [SerializeField] private GameObject _hitPanel;

    private static bool GameIsPaused = false;
   
    private void Awake()
    {
        _gameOver = GameObject.Find("GameOver");
        _gameOver.SetActive(false);

        _settingsPanel = GameObject.Find("SettingsPanel");
        _settingsPanel.SetActive(false);

        _pauseMenuUI = GameObject.Find("PauseMenu");
        _pauseMenuUI.SetActive(false);

        _lowLife = GameObject.Find("LowLifeHud");
        _lowLife.SetActive(false);
    }

    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Escape.triggered)
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
    public void NotifyPlayerHit(int currentLives, float timeRemain)
    {
        if(currentLives <= 3)
        {
            _lowLife.SetActive(true);
        }
        else if(PlayerHealth.Instance.GetLives() > 3)
        {
            _lowLife.SetActive(false);
        }
    }

    void IObserver.NotifyPlayerHit(int currentLives)
    {
        throw new System.NotImplementedException();
    }
}
