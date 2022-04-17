using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObjectInside : MonoBehaviour
{
    public Door door;
    IsObjectInside isObjectInside;
    SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    AudioSource audioSource;
    private void Start()
    {
        isObjectInside = GetComponent<IsObjectInside>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            Debug.Log("Objeto colidiu com botão");
            door.Open();
            spriteRenderer.sprite = newSprite;
            audioSource.Play();
            Destroy(isObjectInside);
        }
    }
}
