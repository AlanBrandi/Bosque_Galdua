using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_Sentry : MonoBehaviour
{
    public Transform Player;
    public float dashEnemySpeed;
    Vector2 playerPosition;
    Rigidbody2D enemyRb;
    bool facingRight = true;
    PatrolFlyEnemy patrol;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public Transform groundCheck;
    public bool isTouchingGround;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        patrol = GetComponent<PatrolFlyEnemy>();
    }
    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayer);
        if (Input.GetKeyDown(KeyCode.E))
        {
            DashOnPlayer();
        }
           


       
        FlipsTowardsPlayer();

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
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

    void DashOnPlayer()
    {

        playerPosition = Player.position - transform.position;
        
        playerPosition.Normalize();
        
        
        

    }
    void FlipsTowardsPlayer()
    {
        float playerDirection = Player.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {
            Flip();
        }
        else if(playerDirection > 0 && !facingRight)
        {
            Flip();
        }
    }
}
