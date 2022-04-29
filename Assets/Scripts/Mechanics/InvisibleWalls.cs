using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{
    public SpriteRenderer[] SR = new SpriteRenderer[1];
    public bool isBackground = true;
    public float colorAlpha = .7f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (SpriteRenderer sr in SR)
            {
                if (isBackground)
                {
                    sr.color = new Color(1f, 1f, 1f, colorAlpha);
                }
                else
                {
                    sr.color= new Color(0f, 0f, 0f, colorAlpha);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (SpriteRenderer sr in SR)
            {
                if (isBackground)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    sr.color = new Color(0f, 0f, 0f, 1f);
                }
            }
        }
    }
    void Start()
    {
        SR[0] = GetComponent<SpriteRenderer>();
    }
}