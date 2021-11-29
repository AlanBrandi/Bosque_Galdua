using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInside : MonoBehaviour
{
    Transform MyTransform;
    Animator lever;
    public Transform spawnLocation;
    public GameObject spawnGO;
    bool playerinside = false;
    

    private void Start()
    {
        lever = GetComponent<Animator>();
        MyTransform = GetComponent<Transform>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerinside == false)
        {
            print("player entrou");
            Instantiate(spawnGO, spawnLocation.position, Quaternion.identity);
            lever.SetBool("IsLeverOn", true);
            playerinside = true;
        }
    }
}