using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPass : MonoBehaviour
{
    BoxCollider2D triggerBox;
    public bool playerPassed = false;

    private void Start()
    {
        triggerBox = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPassed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPassed = false;
        }
    }
}
