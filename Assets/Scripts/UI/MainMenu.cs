using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject settingsPanel;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Credits()
    {
        if (creditsPanel.activeInHierarchy == false)
        {
            animator.SetBool("CreditsOn", true);
        }
        else
        {
            animator.SetBool("CreditsOn", false);
        }
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

    public void CreditsMenu()
    {
        if (creditsPanel.activeInHierarchy == false)
        {
            creditsPanel.SetActive(true);
        }
        else
        {
            creditsPanel.SetActive(false);
        }
    }
}
