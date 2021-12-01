using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameData_SO GameData;
    public TMP_Text txtScore;
    public Slider slider;
    public GameObject DeathPanel;
    public GameObject HIT;
    public GameObject HUD_UI;
    public GameObject FX;
    public GameObject WinPanel;
    int score = 0;
    public GameObject creditosPanel;
    Transform whereToAddEfecct;
    public int Life;
    public GameObject player;
    public GameObject playerManager;
    public IsBlueInside Blue;
    public IsGreenInside Green;
    public IsRedInside Red;
    Scene CurrentScene;

    //================================================================
    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        // txtScore.text = "0";
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

    //================================================================
    //helpers
    public void SetScore(int value)
    {
        score += value;
        txtScore.text = score.ToString();
    }
            //================================================================
            //Handler
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
            DeathPanel.SetActive(true);
        }
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

    public void Creditos()
    {
        creditosPanel.SetActive(true);
    }
    public void Sairreditos()
    {
        creditosPanel.SetActive(false);
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
        if (Blue.blueinside == true && Red.redinside == true && Green.greeninside == true)
        {
            HUD_UI.SetActive(false);
            WinPanel.SetActive(true);
        }
    }
}
