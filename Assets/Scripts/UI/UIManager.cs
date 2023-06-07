using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IObserver
{
    [Header("UI")]
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _gameOver, _pauseMenuUI, _lowLife, _healthUI;

    [Header("Feedback")]
    [SerializeField] private GameObject _hitPanel;

    private static bool GameIsPaused = false;

    private void Start()
    {
        PlayerHealth.Instance.SetLives(6);
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
        if (PlayerHealth.Instance.GetLives() <= 0)
        {
            CloseAllTabs();
            _gameOver.SetActive(true);
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

    private void CloseAllTabs()
    {
        _gameOver.SetActive(false);
        _settingsPanel.SetActive(false);
        _pauseMenuUI.SetActive(false);
        _lowLife.SetActive(false);
        _healthUI.SetActive(false);
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
}
