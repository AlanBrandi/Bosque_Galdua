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
    internal float NextAttackTime = 0f;
    public float AttackRange = 0.5f;
    public int AttackDamage = 5;
    PlayerAttack playerAttack;

    public GameObject PlayerManager;
    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        if (Input.GetKey(LookUp))
        {
            PlayerManager.GetComponent<PlayerAttack>().enabled = false;
            if (Time.time >= NextAttackTime && Time.time >= playerAttack.NextAttackTime)
            {
                if (Input.GetKeyDown(attackButton))
                {
                    playerAttack.AttackSoundAndDelay();
                    MyAni.SetTrigger("Highattack");
                    InvokeRepeating(nameof(Attack), .3f, .016f);
                    Invoke(nameof(AttackCooldown), .7f);
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
            Debug.Log("Inimigo tomou dano por ataque de cima.");
            enemy.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
            AttackCooldown();
        }
    }
    void AttackCooldown()
    {
        CancelInvoke(nameof(Attack));
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
