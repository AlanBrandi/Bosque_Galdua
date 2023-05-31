using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDHealth : MonoBehaviour
{
    [SerializeField] private GameObject[] healthBar;

    private void Update()
    {
        switch (PlayerHealth.Instance.GetLives())
        {
            case 0:
                healthBar[0].SetActive(false);
                healthBar[1].SetActive(false);
                healthBar[2].SetActive(false);
                break;
            case 2:
                healthBar[0].SetActive(true);
                healthBar[1].SetActive(false);
                healthBar[2].SetActive(false);
                break;
            case 4:
                healthBar[0].SetActive(true);
                healthBar[1].SetActive(true);
                healthBar[2].SetActive(false);
                break;
            case 6:
                healthBar[0].SetActive(true);
                healthBar[1].SetActive(true);
                healthBar[2].SetActive(true);
                break;
                
        }
    }
}
    