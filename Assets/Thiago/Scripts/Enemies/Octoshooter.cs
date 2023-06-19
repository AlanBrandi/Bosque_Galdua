using SVS.AI;
using System.Collections;
using UnityEngine;

public class Octoshooter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private float attackDelay = 2f;

    public bool facingRight = true;

    private AIPlayerDetector detector;
    private float playerDirection;
    private Animator anim;
    private float nextAttack = 0f;

    void Start()
    {
        detector = GetComponent<AIPlayerDetector>();
        anim = GetComponent<Animator>();
        nextAttack = Time.time + attackDelay;
    }

    void Update()
    {
        FlipsTowardsPlayer();
    }

    private void FixedUpdate()
    {
        if (detector.playerDetected)
        {
            anim.SetBool("IsDown", false);
            anim.SetBool("IsUp", true);
            if (Time.time >= nextAttack && detector.playerDetected)
            {
                Shoot();
                nextAttack = Time.time + attackDelay;
            }

        }
        else
        {
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", true);
            nextAttack = Time.time + attackDelay;
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

        if (playerDirection < 0 && !facingRight)
        {

            Flip();
        }
        else if (playerDirection > 0 && facingRight)
        {
            Flip();
        }
    }

    private void Shoot()
    {
        attackDelay = 1;

        playerDirection = player.transform.position.x - transform.position.x;

        if (playerDirection < 0)
        {
            GameObject bulletObject = Instantiate(bullet, bulletPos.transform.position, Quaternion.Euler(180, 0, 0));
            OctoshooterBullet bulletComponent = bulletObject.GetComponent<OctoshooterBullet>();
            bulletComponent.Initialize(this);
        }
        else if (playerDirection > 0)
        {
            GameObject bulletObject = Instantiate(bullet, bulletPos.transform.position, Quaternion.Euler(180, 180, 0));
            OctoshooterBullet bulletComponent = bulletObject.GetComponent<OctoshooterBullet>();
            bulletComponent.Initialize(this);
        }
    }
    

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(.5f);
        Shoot();
    }
}
