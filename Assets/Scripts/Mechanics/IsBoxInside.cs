using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBoxInside : MonoBehaviour
{
    public Door door;
    IsBoxInside isBoxInside;
    SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    AudioSource audioSource;
    private void Start()
    {
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
            audioSource.Play();
            Destroy(isBoxInside);
        }
    }
}