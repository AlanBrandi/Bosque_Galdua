using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    AIPath aiPath;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        aiPath = GetComponentInParent<AIPath>();
    }
    private void Update()
    {
        if (aiPath.enabled == true)
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(.2f, .2f, 1f);
            }
            else if (aiPath.desiredVelocity.x <= 0.01f)
            {
                transform.localScale = new Vector3(-.2f, .2f, 1f);
            }
        }
    }

    public void Rotate()
    {
        //Debug.Log("Rotating");
        if (transform.localScale.x > 0f)
        {
            transform.localScale = new Vector3(-.2f, .2f, 1f);
        }
        else if (transform.localScale.x < 0f)
        {
            transform.localScale = new Vector3(.2f, .2f, 1f);
        }
    }
    void PlaySound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}
