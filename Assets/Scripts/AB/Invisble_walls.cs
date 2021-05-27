using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisble_walls : MonoBehaviour
{
    SpriteRenderer MySR;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MySR.color = new Color(1f, 1f, 1f, .7f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MySR.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    void Start()
    {
        MySR = this.GetComponent<SpriteRenderer>();
    }
}