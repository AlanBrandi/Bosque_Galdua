using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_Sentry : MonoBehaviour
{
    public GameObject Player;
    public float dashEnemySpeed;
    Vector2 playerPosition;
    Rigidbody2D enemyRb;
    bool facingRight = true;
    PatrolFlyEnemy patrol;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public Transform groundCheck;
    public bool isTouchingGround;
    public GameObject bullet;
    public Transform bulletPos;
    Quaternion rotationSpear;
    float playerDirection;

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

    public void DashOnPlayer()
    {

        playerPosition = Player.transform.position - transform.position;
        
        playerPosition.Normalize();

        enemyRb.velocity = playerPosition * dashEnemySpeed;
        
        
        

    }
    public void ThrowSpear()
    {
        playerDirection = Player.transform.position.x - transform.position.x;
        if(playerDirection > 0)
        {
            Instantiate(bullet, bulletPos.transform.position, Quaternion.Euler(180, 0, 0));
        }
        else if(playerDirection < 0)
        {
            Instantiate(bullet, bulletPos.transform.position, Quaternion.Euler(180, 180, 0));
        }
    }
        
    void FlipsTowardsPlayer()
    {
        playerDirection = Player.transform.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {
             
            Flip();
        }
        else if(playerDirection > 0 && !facingRight)
        {
            Flip();
        }
    }

    public void RandomState()
    {
        int randomState = Random.Range(0, 2);
        if(randomState == 0)
        {
            DashOnPlayer();
        }
        else if(randomState == 1)
        {
            ThrowSpear();
        }
    }
}
