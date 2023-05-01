using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour
{
    GameObject target;

    public Bomb bomb;
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

    public float bombArcHeight = 2f;



    public bool isTouchingGround;
    private bool canSlowDown;


    [SerializeField] private float forceMagnitude;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayer;

    [SerializeField] private float desaceleracao = 10f;

    public int groundHits = 0;

    bool hasHitGroundThisFrame = false;

    public PhysicsMaterial2D myMaterial;

    private Collider2D collider;

    public float jumpForce = 10f;
    public bool combatStarted = false;

    public bool isBombing;
    public bool isJumping = false;

    private void Awake()
    {
        // myMaterial.bounciness = 1f;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        PhysicsMaterial2D material = collider.sharedMaterial;
        material.bounciness = 1f;
        collider.sharedMaterial = material;
    }
    private void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            isJumping = true;
            DashOnPlayer();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Projectile();
        }




        
       // bomb.direction = -transform.right + Vector3.up;



        FlipsTowardsPlayer();
    }
    void DashOnPlayer()
    {
       
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        StartCoroutine(DelayDash());
        
    }

    IEnumerator WaitBeforeRebounce()
    {
        canSlowDown = false;
        yield return new WaitForSeconds(0.5f);
        canSlowDown = true;
    }


    void FixedUpdate()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayer);

        if (groundCollider != null)
        {
            if (!hasHitGroundThisFrame && isJumping)
            {
                groundHits++;
                hasHitGroundThisFrame = true;
                Invoke("ResetHasHitGroundThisFrame", 0.3f);
            }
        }

        if (groundHits > 8)
        {
            
            PhysicsMaterial2D material = collider.sharedMaterial;
            material.bounciness = 0.4f;
            collider.sharedMaterial = material;
            Vector2 forcaDesaceleracao = new Vector2(-Mathf.Sign(rb.velocity.x), 0f).normalized * desaceleracao;           
            rb.AddForce(forcaDesaceleracao, ForceMode2D.Force);
           // isJumping = false;
            StartCoroutine(ResetGroundHit());         
        }

        if (isTouchingGround)
        {
            StartCoroutine(WaitBeforeRebounce());
        }
    }


    void ResetHasHitGroundThisFrame()
    {
        hasHitGroundThisFrame = false;
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
        isBombing = true;       
        Instantiate(projectile, ProjectilePos.transform.position, Quaternion.identity);
    }



    public void RandomState()
    {
        randomState = Random.Range(0, 2);

        if (randomState == 0)
        {
            Debug.Log("THROW PROJECTILE");
            Projectile();
        }
    }

    IEnumerator DelayDash()
    {
        yield return new WaitForSeconds(.6f);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

    }

    IEnumerator ResetGroundHit()
    {
        yield return new WaitForSeconds(4f);
        isJumping = false;
        groundHits = 0;
    }

}

