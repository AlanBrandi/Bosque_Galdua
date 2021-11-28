using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator MyAni;
    public LayerMask EnemyLayers;
    public KeyCode attackButton;
    public Transform AttackPoint;
    public float AttackRate = 2f;
    float NextAttackTime = 0f;
    public float AttackRange = 0.5f;
    public int AttackDamage = 5;
    Moving moving;
    //Sound
    AudioSource playerManager;
    AudioClip attackSound;

    private void Start()
    {
        moving = GetComponent<Moving>();
        playerManager = GetComponent<AudioSource>();
        attackSound = Resources.Load("sword_swing_1") as AudioClip;
    }

    private void Update()
    {
        if (Time.time >= NextAttackTime)
        {
            if (Input.GetKeyDown(attackButton) && moving.isMoving == true)
            {
                //Sound settings
                int i = Random.Range(1, 3);
                float randomPitch = Random.Range(.9f, 1.1f);
                playerManager.pitch = randomPitch;
                attackSound = Resources.Load("sword_swing_" + i) as AudioClip;
                playerManager.PlayOneShot(attackSound);

                MyAni.SetTrigger("Attack");
                Invoke("Attack", .25f);
                NextAttackTime = Time.time + 1f / AttackRate;
            }
            else if (Input.GetKeyDown(attackButton))
            {
                //Sound settings
                int i = Random.Range(1, 3);
                float randomPitch = Random.Range(.9f, 1.1f);
                playerManager.pitch = randomPitch;
                attackSound = Resources.Load("sword_swing_" + i) as AudioClip;
                playerManager.PlayOneShot(attackSound);

                MyAni.SetTrigger("Attack");
                Invoke("Attack", .2f);
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }

    }

    void Attack()
    {
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        foreach (Collider2D enemy in HitEnemies)
        {
            Debug.Log("Inimigo tomou dano.");
            enemy.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}