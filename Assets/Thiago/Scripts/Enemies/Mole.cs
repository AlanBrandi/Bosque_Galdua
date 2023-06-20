using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{    
    [SerializeField] private PhysicsMaterial2D myMaterial;
    [SerializeField] private Transform undergroundPos;
    private Rigidbody2D rb;
    private Vector2 playerPosition;
    private Transform player;
    private Collider2D collider;
    private EnemiesScript enemy;
    private GameObject target;

    [SerializeField] private Bomb bomb;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectilePos;    
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayer;
    [SerializeField] private LayerMask playerLayer;      
    
    [SerializeField] private bool facingRight = true;
    [HideInInspector] public bool playerIsInPlat;
    private bool isTouchingGround;
    private bool canSlowDown;
    private bool combatStarted = false;
    private bool hasHitGroundThisFrame = false;
    private bool isBombing;
    private bool isJumping = false;
    private bool isRainRock = false;
    private bool makeCont = true;
    private bool doOnce = false;

    private int groundHits = 0;
    private int randomNumber = 0;
    private int contPlayerUp;
    private int cont = 0;
    private int randomState = 0;

    [SerializeField] private float forceMagnitude;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float desaceleracao = 10f;
    private float raycastDistance = 10f;
    private float minX = -33.81f;
    private float maxX = -16.41f;
    private float speed = 10f;
    private float attackDelay = 1f;
    private float nextAttack = 0f;
    private float playerDirection;
    private float nextBomb = 0;
    private float bombRate;
    private float contBomb = 0;
    private float bombArcHeight = 2f;

    private LeverPoisonCure[] levers;
    private List<LeverPoisonCure> poisonCures = new List<LeverPoisonCure>();
    private GameObject[] objectsWithTag;

    private EnemiesScript mole;

    public GameObject leverSpawn;
    [SerializeField] private SpawnerRockRain spawner;


    public GameObject lightPurpleUnderground;

    public Collider2D blackScreen;

    public AudioSource audioJump;
    public AudioSource audioDash;
    public AudioSource audioDashUp;
    public AudioSource audioBigStomp;
    public AudioSource audioHitWall;
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
        mole = GetComponent<EnemiesScript>();

        PhysicsMaterial2D material = collider.sharedMaterial;
        material.bounciness = 0.4f;
        material.friction = 0.0f;
        
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

        nextAttack += Time.deltaTime;
        if (nextAttack >= attackDelay)
        {
            RandomState();
            nextAttack = 0;
            nextAttack = 0;
        }

        FlipsTowardsPlayer();
    }    
    void FixedUpdate()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayer);

        if (groundCollider != null)
        {
            if (!hasHitGroundThisFrame)
            {
                if (isJumping)
                {
                    audioHitWall.Play();
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
            if (isRainRock && groundHits >= 2)
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
                isRainRock = false;
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
            nextAttack = 0;
            attackDelay = 1.8f;
        }

        if (Mathf.Abs(undergroundPos.transform.position.y - transform.position.y) < 0.5f)

        {
lightPurpleUnderground.SetActive(true);
            if (makeCont)
            {
                randomNumber = Random.Range(1, 5);
                makeCont = false;
            }

            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance, playerLayer);
            Debug.DrawRay(transform.position, Vector2.up * raycastDistance, Color.yellow);
            if (hit.collider != null)
            {
                Debug.Log("Player est� diretamente acima do inimigo!");
                if (!hasHitGroundThisFrame)
                {
                    contPlayerUp++;
                    hasHitGroundThisFrame = true;
                    Invoke("ResetHasHitGroundThisFrame", .5f);
                }

            }


            if (contPlayerUp <= randomNumber)
            {
                float pingPong = Mathf.PingPong(Time.time * speed, maxX - minX);
                float posX = minX + pingPong;
                transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            }
            else
            {
                audioDashUp.Play();
                lightPurpleUnderground.SetActive(false);
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0.5f;
                Physics2D.IgnoreLayerCollision(gameObject.layer, 11, false);
                rb.AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
                contPlayerUp = 0;
                makeCont = true;
                nextAttack = 0;
                attackDelay = 2f;
                blackScreen.isTrigger = true;
                StartCoroutine(backToCollider());
            }
        }


        if (playerIsInPlat && !doOnce)
        {
            StartCoroutine(resetHits());
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

    public bool isFacingRight;
    void FlipsTowardsPlayer()
    {
        playerDirection = target.transform.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {
            isFacingRight = false;
            Flip();
        }
        else if (playerDirection > 0 && !facingRight)
        {
            isFacingRight = true;
            Flip();
        }
    }
    void DashOnPlayer()
    {
        audioJump.Play();
        
        isJumping = true;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        PhysicsMaterial2D material = collider.sharedMaterial;
        material.bounciness = 1f;
        material.friction = 0f;
        collider.sharedMaterial = material;
        StartCoroutine(DelayDash());

    }
    public void Projectile()
    {
        isBombing = true;
        Instantiate(projectile, projectilePos.transform.position, Quaternion.identity);

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
    public void UndergroundAttack()
    {
        audioJump.Play();
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        PhysicsMaterial2D material = collider.sharedMaterial;
        material.bounciness = 0.4f;
        material.friction = 1f;
        collider.sharedMaterial = material;
        StartCoroutine(DelayDashUnderground());
    }
    public void RandomState()
    {
        randomState = Random.Range(0, 3);

        if (!playerIsInPlat)
        {
            
            if (randomState == 0)
            {
                isBombing = true;
                isJumping = false;
                isRainRock = false;
                nextAttack = 0;
                attackDelay = 0.8f;
                Projectile();
            }
            else if (randomState == 1)
            {
                isJumping = true;
                isBombing = false;
                isRainRock = false;
                nextAttack = 0;
                attackDelay = 100;
                doOnce = false;
                DashOnPlayer();
            }
            else if (randomState == 2)
            {
                isJumping = false;
                isBombing = false;
                isRainRock = false;
                nextAttack = 0;
                attackDelay = 100;
                doOnce = false;
                UndergroundAttack();
            }
        }
        else
        {
            isRainRock = true;
            isJumping = false;
            isBombing = false;
            nextAttack = 0;
            if (poisonCures[0].timer == 0)
            {
                attackDelay = 11.2f - poisonCures[1].timer;
            }
            else
            {
                attackDelay = 11.2f - poisonCures[0].timer;
            }
            
            RainRock();
        }
    }

    IEnumerator backToCollider()
    {
        yield return new WaitForSeconds(.3f);
        blackScreen.isTrigger = false;
    }
    IEnumerator SpawnLever()
    {
        
        yield return new WaitForSeconds(2f);
        leverSpawn.SetActive(true);
        Destroy(this.gameObject);

    }
    IEnumerator DelayDash()
    {
        yield return new WaitForSeconds(.6f);
        audioDash.Play();
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

    }
    IEnumerator DelayDashUnderground()
    {
        yield return new WaitForSeconds(.6f);
        Vector2 direction = (undergroundPos.transform.position - transform.position).normalized;
        rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 11, true);
    }
    IEnumerator DelayRainRock()
    {
        yield return new WaitForSeconds(.6f);
        audioBigStomp.Play();
        rb.AddForce(new Vector2(0f, -jumpForce * 2f), ForceMode2D.Impulse);

    }
    IEnumerator DelayExitRainRock()
    {
        float timer;

        if (poisonCures[0].timer == 0)
        {             
            timer = 12 - poisonCures[1].timer;
        }
        else
        {
            timer = 12 - poisonCures[0].timer;
        }
        enemy.screenShake.startShake(timer, .3f);
        yield return new WaitForSeconds(timer);
        groundHits = 0;
        isRainRock = false;
        cont = 0;
    }
    IEnumerator WaitBeforeRebounce()
    {
        canSlowDown = false;
        yield return new WaitForSeconds(0.5f);
        canSlowDown = true;
    }
    IEnumerator resetHits()
    {
        doOnce = true;
        contPlayerUp = 10;
        groundHits = 10;
        yield return new WaitForSeconds(0.1f);
        contPlayerUp = 0;
        groundHits = 0;
    }
}

