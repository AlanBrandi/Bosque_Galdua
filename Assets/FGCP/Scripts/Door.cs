using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject doorObject;
    SpriteRenderer sr;
    AudioSource audioSource;
    BoxCollider2D doorCollider;
    [SerializeField]
    bool playSound, disableCollider, changeColor, changeLayer;
    public float r = 1, g = 1, b = 1, alpha = 1;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        doorCollider = GetComponent<BoxCollider2D>();
        doorObject = gameObject;
    }

    public void Open()
    {
        if (playSound == true)
        {
            audioSource.Play();
        }
        if (disableCollider == true)
        {
            Invoke(nameof(DisableCollider), 1.5f);
        }
        if (changeLayer == true)
        {
            doorObject.layer = 16;
        }
        if (changeColor == true)
        {
            sr.color = new Color(r, g, b, alpha);
        }
    }

    void DisableCollider()
    {
        doorCollider.enabled = false;
    }
}
