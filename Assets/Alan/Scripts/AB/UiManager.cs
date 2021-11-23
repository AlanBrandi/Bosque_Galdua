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
    Transform whereToAddEfecct;
    public int Life;
    public GameObject player;
    public GameObject playerManager;
    public IsBlueInside Blue;
    public IsGreenInside Green;
    public IsRedInside Red;
    public GameObject FakeUi;
    //================================================================
    private void Start()
    {
        // txtScore.text = "0";
        Life = GameData.lives;
        slider.value = GameData.lives;
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

        if (Life <= 0)
        {
            HUD_UI.SetActive(false);
            DeathPanel.SetActive(true);
        }
    }
    public void MyLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Update()
    {
        whereToAddEfecct = player.transform;
        if (Blue.blueinside == true && Red.redinside == true && Green.greeninside == true)
        {
            FakeUi.SetActive(false);
            HUD_UI.SetActive(false);
            WinPanel.SetActive(true);
        }
    }
}
