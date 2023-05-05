using SVS.AI;
using System.Collections;
using UnityEngine;

public class Lance_Sentry : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float dashEnemySpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;

    [SerializeField] private float forceMagnitude;
    [SerializeField] private float desaceleracao = 10f;

    public float attackDelay = 2f;

    private bool isTouchingGround;
    private bool canSlowDown;
    private bool isFlying;
    private bool facingRight = true;
    private bool isDashing, isShooting, isDashingLow;

    private float targetY;
    private float playerDirection;
    private float nextAttack = 0f;

    private Rigidbody2D enemyRb;
    private AIPlayerDetector detector;
    private PatrolFlyEnemy patrol;

    private bool IsDashing { get { return isDashing; } }
    private bool IsShooting { get { return isShooting; } }
    private bool IsDashingLow { get { return isDashingLow; } }

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        targetY = transform.position.y;
        detector = GetComponent<AIPlayerDetector>();
    }
    void Update()
    {
        if (Time.time >= nextAttack && detector.playerDetected)
        {
            RandomState();
            nextAttack = Time.time + attackDelay;
        }

        FlipsTowardsPlayer();
    }
    void FixedUpdate()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayer);

        if (isTouchingGround)
        {
            StartCoroutine(WaitBeforeRebounce());
        }

        if (canSlowDown && transform.position.y > targetY && !isFlying)
        {
            enemyRb.AddForce(-enemyRb.velocity.normalized * desaceleracao, ForceMode2D.Force);
            float tolerance = 0.1f; // tolerância de 10% da velocidade atual
            if (Mathf.Abs(enemyRb.velocity.y) <= Mathf.Abs(enemyRb.velocity.magnitude * tolerance))
            {
                canSlowDown = false;
                enemyRb.velocity = Vector2.zero;
                isFlying = true;
            }
        }

        if (isDashingLow && player.transform.position.y + transform.position.y < -0.5f)
        {
            StartCoroutine(LowDashing());
            enemyRb.velocity = Vector2.zero;
        }
        if (isDashingLow)
        {
            float targetY = player.transform.position.y;
            float newY = Mathf.MoveTowards(transform.position.y, targetY, dashEnemySpeed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, newY);
        }
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
        playerDirection = player.transform.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {

            Flip();
        }
        else if (playerDirection > 0 && !facingRight)
        {
            Flip();
        }
    }
    public void ThrowSpear()
    {
        playerDirection = player.transform.position.x - transform.position.x;

        if (playerDirection > 0)
        {
            Instantiate(bullet, bulletPos.transform.position, Quaternion.Euler(180, 0, 0));
        }
        else if (playerDirection < 0)
        {
            Instantiate(bullet, bulletPos.transform.position, Quaternion.Euler(180, 180, 0));
        }
        isShooting = false;
    }
    void DashOnPlayer()
    {
        isFlying = false;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
        isDashing = false;
    }
    public void LowDash()
    {
        isDashingLow = true;
    }
    public void RandomState()
    {
        int randomState = Random.Range(0, 3);


        if (randomState == 0)
        {
            isDashing = true;
            forceMagnitude = 10;
            attackDelay = 2f;
            nextAttack = attackDelay;
            DashOnPlayer();
        }
        else if (randomState == 1)
        {
            isShooting = true;
            attackDelay = 2f;
            nextAttack = attackDelay;
            ThrowSpear();
        }
        else if (randomState == 2)
        {
            isDashingLow = true;
            attackDelay = 6f;
            nextAttack = attackDelay;
            forceMagnitude = 1;
            LowDashing();
        }
    }
    IEnumerator LowDashing()
    {
        yield return new WaitForSeconds(2f);

        Vector2 direction = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
        isDashingLow = false;
        enemyRb.AddForce(-enemyRb.velocity.normalized * desaceleracao, ForceMode2D.Force);

        StartCoroutine(StopLowDashing());
    }
    IEnumerator StopLowDashing()
    {
        yield return new WaitForSeconds(1f);

        enemyRb.velocity = Vector2.zero;
        float newY = Mathf.MoveTowards(transform.position.y, targetY, dashEnemySpeed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, newY);
    }
    IEnumerator WaitBeforeRebounce()
    {
        canSlowDown = false;
        yield return new WaitForSeconds(0.5f);
        canSlowDown = true;
    }
}