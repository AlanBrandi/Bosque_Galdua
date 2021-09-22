using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TMP_Text txtScore;
    public Slider slider;
    public GameObject DeathPanel;
    public GameObject HIT;
    public GameObject HUD_UI;
    public GameObject FX;
    public GameObject WinPanel;
    int score = 0;
    public int Life;
    public GameObject player;
    public IsBlueInside Blue;
    public IsGreenInside Green;
    public IsRedInside Red;
    public GameObject FakeUi;
    //================================================================
    private void Start()
    {
       // txtScore.text = "0";
        Life = player.GetComponent<MyHealthSystem>().life;
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
        slider.value = Life;
        Instantiate(HIT, player.transform.position, Quaternion.identity);

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
        if (Blue.blueinside == true && Red.redinside == true && Green.greeninside == true)
        {
            FakeUi.SetActive(false);
            HUD_UI.SetActive(false);
            WinPanel.SetActive(true);
        }
    }
}
