using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighAttack : MonoBehaviour
{
    Animator animator;
    public KeyCode LookUp;
    LayerMask EnemyLayers;
    public KeyCode attackButton;
    public Transform AttackPoint;
    internal float NextAttackTime = 0f;
    public float AttackRange = 0.5f;
    public int AttackDamage = 5;
    PlayerAttack playerAttack;
    HoldAndThrow holdAndThrow;
    Jumping jumping;
    private PlayerMovement mov;
    private void Start()
    {
        jumping = GetComponent<Jumping>();
        holdAndThrow = FindObjectOfType<HoldAndThrow>();
        animator = GetComponentInChildren<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        EnemyLayers = playerAttack.EnemyLayers;
        mov = GetComponentInChildren<PlayerMovement>();
    }
    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Move.ReadValue<Vector2>().y > 0.4)
        {
            playerAttack.enabled = false;
            if (Time.time >= NextAttackTime && Time.time >= playerAttack.NextAttackTime)
            {
                if ((UserInput.instance.playerController.InGame.Attack.triggered && holdAndThrow.Estado != "Segurando" && mov.CanJump()))
                {
                    playerAttack.AttackSoundAndDelay();
                    animator.SetTrigger("Highattack");
                    InvokeRepeating(nameof(Attack), .128f, .016f);
                    Invoke(nameof(AttackCooldown), .288f);
                }
            }
        }
        else if (UserInput.instance.playerController.InGame.Move.ReadValue<Vector2>().y < 0.4)
        {
            playerAttack.enabled = true;
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
