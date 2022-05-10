using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    AIPath aiPath;
    AudioSource audioSource;
    float PointPosition;
    public bool facingRight = true;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        aiPath = GetComponentInParent<AIPath>();
    }
    private void Update()
    {
        
    }

   
    void PlaySound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.Play();
    }

    void Flip()
    {
        if (facingRight)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;

        }
        else if (!facingRight)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }

    }
    void FlipsTowardsPoint()
    {
        PointPosition = (Player.transform.position.x - transform.position.x);
        if (PointPosition < 0 && facingRight)
        {
            Debug.Log("VAI PRA ESQUERDA");
            Flip();
        }
        else if (PointPosition > 0 && !facingRight)
        {
            Debug.Log("VAI PRA DIREITA");
            Flip();
        }
    }
}
