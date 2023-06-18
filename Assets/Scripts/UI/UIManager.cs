using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour, IObserver
{
    [Header("UI")]
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _gameOver, _pauseMenuUI, _lowLife, _healthUI;
    [SerializeField] private LevelChanger _levelChanger;

    
    [Header("AudioMixer")]
    [SerializeField] private AudioMixerSnapshot OpenMenu;
    [SerializeField] private AudioMixerSnapshot ClosedMenu;
    
    [Header("Feedback")]
    [SerializeField] private GameObject _hitPanel;

    [Header("EventSystem")] 
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject go1;
    [SerializeField] private GameObject go2;

    [Header("EventSystem")]
    private static bool GameIsPaused = false;

    private void Start()
    {
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.SetLives(6);
        }
    }

    private void Update()
    {
        //if (UserInput.instance != null)
        {
            if (UserInput.instance != null && UserInput.instance.playerController.InGame.Escape.triggered)
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
            //Colocar isso fora do update. Fazer um CheckLives() toda vez que o jogador levar dano.
            if (PlayerHealth.Instance != null && PlayerHealth.Instance.GetLives() <= 0)
            {
                CloseAllTabs();
                _gameOver.SetActive(true);
            }
        }

    }
    private void Pause()
    {
        OpenMenu.TransitionTo(0f);
        _pauseMenuUI.SetActive(true);
        eventSystem.SetSelectedGameObject(go1);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void Resume()
    {
        ClosedMenu.TransitionTo(0f);
        _pauseMenuUI.SetActive(false);
        eventSystem.SetSelectedGameObject(null);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void ToggleSettings()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeInHierarchy);
        if (_settingsPanel.activeInHierarchy)
        {
            eventSystem.SetSelectedGameObject(go1);
        }
        else
        {
            eventSystem.SetSelectedGameObject(go2);
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
        _levelChanger.FadeToLevel("Menu");
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void NotifyPlayerHit(int currentLives, float timeRemain)
    {
        if (currentLives <= 3)
        {
            _lowLife.SetActive(true);
        }
        else if (PlayerHealth.Instance.GetLives() > 3)
        {
            _lowLife.SetActive(false);
        }
    }
}