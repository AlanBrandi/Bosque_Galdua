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
    public float AttackRange= 0.5f;
    public int AttackDamage = 5;

    private void Update()
    {
        if(Time.time >= NextAttackTime)
        {
            if (Input.GetKeyDown(attackButton))
            {
                Attack();
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }
       
    }


    void Attack()
    {
        MyAni.SetTrigger("Attack");

       Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
        
        foreach(Collider2D enemy in HitEnemies)
        {
            Debug.Log("SLIME TOMOU DANO");
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
