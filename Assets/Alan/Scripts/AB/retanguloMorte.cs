using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retanguloMorte : MonoBehaviour
{
    public UiManager Ui;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ui.SetLife(0);
        }
    }
}
