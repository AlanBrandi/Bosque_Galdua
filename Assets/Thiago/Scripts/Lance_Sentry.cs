using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_Sentry : MonoBehaviour
{
    public Transform player;
    public float attackPlayerSpeed;
    Vector2 playerPosition;
    Rigidbody2D enemyRb;
    bool facingRight = true; 

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackPlayer();
        }
        FlipsTowardsPlayer();

        
    }

    void Flip()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
            
        }
        else if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
        
    }

    void AttackPlayer()
    {
        playerPosition = player.position - transform.position;
        playerPosition.Normalize();
        enemyRb.velocity = playerPosition * attackPlayerSpeed;
    }
    void FlipsTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {
            facingRight = true;
            Flip();
        }
        else if(playerDirection > 0 && !facingRight)
        {
            facingRight = false;
            Flip();
        }
    }
}
