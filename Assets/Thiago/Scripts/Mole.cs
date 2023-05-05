using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    GameObject target;

    public Bomb bomb;
    public GameObject projectile;
    public Transform ProjectilePos;
    public float attackrate;
    int randomState = 0;
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

    private EnemiesScript enemy;


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
    public bool isRainRock = false;
    public bool playerIsInPlat;

    public float attackDelay = 2f;
    private float nextAttack = 0f;

    public SpawnerRockRain spawner;

    private LeverPoisonCure[] levers;
    List<LeverPoisonCure> poisonCures = new List<LeverPoisonCure>();
    GameObject[] objectsWithTag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    private void Start()
    {

        enemy = GetComponent<EnemiesScript>();
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        objectsWithTag = GameObject.FindGameObjectsWithTag("PoisonCure");

        // Crie uma lista para armazenar os scripts encontrados
        

        // Percorra cada objeto encontrado e adicione o componente PoisonCure à lista
        foreach (GameObject obj in objectsWithTag)
        {
            LeverPoisonCure script = obj.GetComponent<LeverPoisonCure>();
            if (script != null)
            {
                poisonCures.Add(script);
            }
        }

        

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerIsInPlat)
        {
            // isJumping = true;
            // DashOnPlayer();
            RainRock();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
           // Projectile();
        }


        if (Time.time >= nextAttack)
        {
            //RandomState();
           // nextAttack = Time.time + attackDelay;
        }







        FlipsTowardsPlayer();
    }
    void DashOnPlayer()
    {
        isJumping = true;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        PhysicsMaterial2D material = collider.sharedMaterial;
        material.bounciness = 1f;
        material.friction = 0f;
        collider.sharedMaterial = material;
        StartCoroutine(DelayDash());
        
    }

    IEnumerator WaitBeforeRebounce()
    {
        canSlowDown = false;
        yield return new WaitForSeconds(0.5f);
        canSlowDown = true;
    }

    private int cont = 0;
    void FixedUpdate()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayer);

        if (groundCollider != null)
        {
            if (!hasHitGroundThisFrame)
            {
                if (isJumping)
                {
                    enemy.screenShake.startShake(.35f, 0.5f);
                    groundHits++;
                    hasHitGroundThisFrame = true;
                    Invoke("ResetHasHitGroundThisFrame", 0.3f);
                }
                else if (isRainRock)
                {
                    groundHits++;
                    hasHitGroundThisFrame = true;
                    Invoke("ResetHasHitGroundThisFrame", 0.3f);
                }
                
                
            }
            if(isRainRock && groundHits >=2)
            {
               
                if (cont == 0)
                {
                    if (poisonCures[0].timer == 0)
                    {
                        spawner.durationTimer = poisonCures[1].timer;
                    }
                    else
                    {
                        spawner.durationTimer = poisonCures[0].timer;
                    }
                    spawner.isSpawning = true;
                    StartCoroutine(spawner.SpawnRocks());
                    cont++;
                }
                enemy.screenShake.startShake(5f,.25f);                
                StartCoroutine(DelayExitRainRock());
            }
        }

        if (groundHits > 8)
        {
            
            PhysicsMaterial2D material = collider.sharedMaterial;
            material.bounciness = 0.4f;
            material.friction = 1.0f;
            collider.sharedMaterial = material;
            Vector2 forcaDesaceleracao = new Vector2(-Mathf.Sign(rb.velocity.x), 0f).normalized * desaceleracao;           
            rb.AddForce(forcaDesaceleracao, ForceMode2D.Force);
            isJumping = false;
            groundHits = 0;
            attackDelay = 7.5f;
            nextAttack = attackDelay;
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
    public void RainRock()
    {
        isRainRock = true;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        PhysicsMaterial2D material = collider.sharedMaterial;
        material.bounciness = 0.15f;
        material.friction = 1f;
        collider.sharedMaterial = material;
        StartCoroutine(DelayRainRock());
    }



    public void RandomState()
    {
        randomState = Random.Range(0, 2);

        if (randomState == 0)
        {
            isBombing = true;
            isJumping = false;
            attackDelay = 1;
            nextAttack = attackDelay;
            Projectile();
        }
        else if(randomState == 1)
        {
            isJumping = true;
            isBombing = false;
            attackDelay = 100;
            nextAttack = attackDelay;
            DashOnPlayer();
        }
    }

    IEnumerator DelayDash()
    {
        yield return new WaitForSeconds(.6f);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

    }
    IEnumerator DelayRainRock()
    {
        yield return new WaitForSeconds(.6f);
        rb.AddForce(new Vector2(0f, -jumpForce * 2f), ForceMode2D.Impulse); 

    }
    IEnumerator DelayExitRainRock()
    {
              
        yield return new WaitForSeconds(5f);
        groundHits = 0;
        isRainRock = false;
        cont = 0;
    }
}

