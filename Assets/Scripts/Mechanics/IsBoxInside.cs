using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class IsBoxInside : MonoBehaviour
{
    public Door door;
    IsBoxInside isBoxInside;
    SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    AudioSource audioSource;
    Light2D light2D;
    private void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
        audioSource = GetComponent<AudioSource>();
        isBoxInside = GetComponent<IsBoxInside>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("Box colidiu com botão");
            door.Open();
            spriteRenderer.sprite = newSprite;
            light2D.color = Color.green;
            audioSource.Play();
            Destroy(isBoxInside);
        }
    }
}