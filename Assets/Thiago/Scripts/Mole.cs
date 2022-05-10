using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    GameObject target;

    public Bomb bomb;
    public float speed;
    public float dashSpeed;
    public GameObject projectile;
    public Transform ProjectilePos;
    public float attackrate;
    int randomState = 0;
    float nextAttack = 0f;
    bool facingRight = true;
    float playerDirection;
    float nextBomb = 0;
    public float bombRate;
    float contBomb = 0;
    public Transform player;
    Rigidbody2D rb;
    Vector2 playerPosition;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        Vector2 targett = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, targett, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Time.time > nextAttack)
        {
            contBomb = 0;
            nextAttack = Time.time + attackrate;
            RandomState();
        }

        if (Time.time > nextBomb && randomState == 0 && contBomb < 4)
        {
            contBomb++;
            nextBomb = Time.time + bombRate;
            Projectile();
        }
        bomb.bombSpeed = (target.transform.position.x - transform.position.x) - 2;
        if (bomb.bombSpeed < 0)
        {
            
            bomb.bombSpeed = bomb.bombSpeed * -1;
        }
        else if(bomb.bombSpeed > 0)
        {
            bomb.bombSpeed = (target.transform.position.x - transform.position.x) + 2;
        }

            bomb.direction = -transform.right + Vector3.up;
        
  

        FlipsTowardsPlayer();
    }

    void Flip()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = false;

        }
        else if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = true;
        }

    }

    void FlipsTowardsPlayer()
    {
        playerDirection = target.transform.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {

            Flip();
        }
        else if (playerDirection > 0 && !facingRight)
        {
            Flip();
        }
    }


    public void Projectile()
    {      
        Instantiate(projectile, ProjectilePos.transform.position, Quaternion.identity);
    }
    
    
   
    public void RandomState()
    {
        randomState = Random.Range(0, 2);
       
        if(randomState == 0)
        {
            Debug.Log("THROW PROJECTILE");
            Projectile();
        }
        else if (randomState == 1)
        {
            Debug.Log("DASH");
            StartCoroutine(dash());
        }
    }

    IEnumerator dash()
    {
        float x = speed;
        speed = dashSpeed;

        yield return new WaitForSeconds(.35f);
        speed = x;
    }
}
