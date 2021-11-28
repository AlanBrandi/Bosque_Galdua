using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoSound : MonoBehaviour
{
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 25)
        {
            audioSource.Play();
        }
    }
}
