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

    private void Update()
    {
        if (Input.GetKey(LookUp))
        {
            PlayerManager.GetComponent<PlayerAttack>().enabled = false;
            if (Time.time >= NextAttackTime)
            {
                if (Input.GetKeyDown(attackButton))
                {
                    Attack();
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
        MyAni.SetTrigger("Highattack");

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
