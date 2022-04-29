using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IsTroncoInside : MonoBehaviour
{
    GameObject WrongSide;
    Animator WSAnim;

    private void Start()
    {
        WrongSide = GameObject.Find("WrongSide");
        WSAnim = WrongSide.GetComponent<Animator>();
        WrongSide.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tronco"))
        {
            Debug.Log("Tronco entrou");
            WrongSide.SetActive(true);
            WSAnim.SetTrigger("LogOn");
            Invoke(nameof(LogOff), 3);
        }
    }

    void LogOff()
    {
        WrongSide.SetActive(false);
    }
}
