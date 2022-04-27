using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    int score = 0;
    GameObject sliderHP;
    GameObject gameOver;
    GameObject HUD_UI;
    GameObject WinPanel;
    GameObject settingsPanel;
    GameObject pauseMenuUI;
    Transform whereToAddEfecct;
    Slider slider;

    public int Life;
    public GameData_SO GameData;
    public GameObject HIT;
    public GameObject FX;

    GameObject player;
    GameObject playerManager;
    public static bool GameIsPaused = false;
    public GameObject creditosPanel;
    Scene CurrentScene;
   
    private void Start()
    {
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        HUD_UI = GameObject.Find("Health_QuestUi");
        sliderHP = GameObject.Find("SliderHP");
        slider = sliderHP.GetComponent<Slider>();
        WinPanel = GameObject.Find("WinPanel");
        settingsPanel = GameObject.Find("SettingsPanel");
        settingsPanel.SetActive(false);
        pauseMenuUI = GameObject.Find("PauseMenu");
        pauseMenuUI.SetActive(false);
        player = GameObject.Find("Player");
        playerManager = GameObject.Find("PlayerManager");


        CurrentScene = SceneManager.GetActiveScene();
        Life = GameData.lives;
        slider.value = GameData.lives;
        if (whereToAddEfecct == null)
        {
            if(player != null) 
            {
                whereToAddEfecct = player.transform;
            }
        }
    }

    private void Update()
    {
        if(whereToAddEfecct == null)
        {
            whereToAddEfecct = this.transform;
        }
        if(player == null)
        {
            whereToAddEfecct = this.transform;
        }
        else
        {
            whereToAddEfecct = player.transform;
        }
        //if (Blue.blueinside == true && Red.redinside == true && Green.greeninside == true)
        //{
        //    HUD_UI.SetActive(false);
        //    WinPanel.SetActive(true);
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true && settingsPanel.activeInHierarchy == false)
            {
                Resume();
            }
            else if (GameIsPaused == true && settingsPanel.activeInHierarchy == true)
            {
                ToggleSettings();
            }
            else
            {
                Pause();
            }
        }
    }

     public void Sair()
     { 
        Application.Quit();
     }
     
    public void SetLife(int Life)
    {
        slider.value = GameData.lives;
        Instantiate(HIT, whereToAddEfecct.position, Quaternion.identity);
        AudioSource hitSFX = HIT.GetComponent<AudioSource>();
        float randomPitch = Random.Range(0.8f, 1.4f);
        hitSFX.pitch = randomPitch;

        if (Life <= 0)
        {
            HUD_UI.SetActive(false);
            gameOver.SetActive(true);
        }
    }
    public void FadeOut(Animator fade)
    {
        fade.SetTrigger("FadeOut");
    }
    public void MyLoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) == CurrentScene)
        {
            GameData.lives = 15;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
      
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void ToggleSettings()
    {
        if (settingsPanel.activeInHierarchy == false)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }
}
