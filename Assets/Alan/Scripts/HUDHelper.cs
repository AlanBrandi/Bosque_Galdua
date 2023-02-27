using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDHelper : MonoBehaviour
{
    public GameObject HUDScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HUDScreen.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HUDScreen.SetActive(false);
        }
    }
}
