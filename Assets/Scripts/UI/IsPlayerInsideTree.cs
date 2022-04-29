using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IsPlayerInsideTree : MonoBehaviour
{
    public TMP_Text TopText;
    public TMP_Text DownText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TopText.text = "Resolva o enigma";
            DownText.text = "Tenha cuidado";
        }
    }
}
