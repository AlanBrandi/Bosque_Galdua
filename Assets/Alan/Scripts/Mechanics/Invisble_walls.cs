using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisble_walls : MonoBehaviour
{
    public SpriteRenderer[] SR = new SpriteRenderer[1];
    public float colorAlpha = .7f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (SpriteRenderer sr in SR)
            {
                sr.color= new Color(1f, 1f, 1f, colorAlpha);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (SpriteRenderer sr in SR)
            {
                sr.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
    void Start()
    {
        SR[0] = GetComponent<SpriteRenderer>();
    }
}