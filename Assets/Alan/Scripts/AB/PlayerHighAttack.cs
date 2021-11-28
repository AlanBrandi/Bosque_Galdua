using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighAttack : MonoBehaviour
{
    public Animator MyAni;
    public KeyCode LookUp;

    public LayerMask EnemyLayers;
    public KeyCode attackButton;
    public Transform AttackPoint;
    public float AttackRate = 2f;
    float NextAttackTime = 0f;
    public float AttackRange = 0.5f;
    public int AttackDamage = 5;

    public GameObject PlayerManager;

    //Sound
    AudioSource playerManager;
    AudioClip attackSound;

    private void Start()
    {
        playerManager = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(LookUp))
        {
            PlayerManager.GetComponent<PlayerAttack>().enabled = false;
            if (Time.time >= NextAttackTime)
            {
                if (Input.GetKeyDown(attackButton))
                {
                    //Sound settings
                    int i = Random.Range(1, 3);
                    float randomPitch = Random.Range(.9f, 1.1f);
                    playerManager.pitch = randomPitch;
                    attackSound = Resources.Load("sword_swing_" + i) as AudioClip;
                    playerManager.PlayOneShot(attackSound);

                    MyAni.SetTrigger("Highattack");
                    Invoke("Attack", .3f);
                    NextAttackTime = Time.time + 1f / AttackRate;
                }
            }

        }
        else if (Input.GetKeyUp(LookUp))
        {
            PlayerManager.GetComponent<PlayerAttack>().enabled = true;
        }

    }

    void Attack()
    {
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        foreach (Collider2D enemy in HitEnemies)
        {
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
