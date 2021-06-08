using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public UiManager ui;
    public int life = 3;

    private void Start()
    {
        life = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemies"))
        {
            life = life - 1;
            ui.SetLife(life);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            life = life - 1;
            ui.SetLife(life);
        }
    }
}
