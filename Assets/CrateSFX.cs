using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSFX : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 20)
        {
            if (gameObject != null)
            {
                audioSource.pitch = collision.relativeVelocity.magnitude / 30;
                audioSource.PlayOneShot(clip, (collision.relativeVelocity.magnitude / 30));
            }
        }
    }
}
