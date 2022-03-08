using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retanguloMorte : MonoBehaviour
{
    MyHealthSystem healthSystemPlayer;
    GameObject playerManager;
    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
        healthSystemPlayer = playerManager.GetComponent<MyHealthSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthSystemPlayer.Die();
        }
    }
}
