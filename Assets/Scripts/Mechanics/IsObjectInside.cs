using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class IsObjectInside : MonoBehaviour
{
    public Door door;
    IsObjectInside isObjectInside;
    SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    AudioSource audioSource;
    Light2D light2D;
    private void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
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
            light2D.color = Color.green;
            audioSource.Play();
            Destroy(isObjectInside);
        }
    }
}
