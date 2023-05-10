using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    public LayerMask EnemyLayers;
    public Transform AttackPoint, JumpingAttackPoint;
    public float AttackRate = 2f;
    public float AttackRange = 0.5f, JumpingAttackRange;
    public int AttackDamage = 5;
    public float NextAttackTime = 0f;
    Moving moving;
    Jumping jumping;
    PlayerHighAttack playerHighAttack;
    HoldAndThrow holdAndThrow;

    //Sound
    AudioSource swordSounds;
    AudioClip attackSound;

    private void Start()
    {
        holdAndThrow = FindObjectOfType<HoldAndThrow>();
        animator = GetComponentInChildren<Animator>();
        moving = GetComponent<Moving>();
        jumping = GetComponent<Jumping>();
        AudioSource[] audios = GetComponentsInChildren<AudioSource>();
        swordSounds = audios[0];
        playerHighAttack = GetComponent<PlayerHighAttack>();
        attackSound = Resources.Load("sword_swing_1") as AudioClip;
        animator.SetBool("HasSword", true);
    }

    private void Update()
    {
        if (Time.time >= NextAttackTime && Time.time >= playerHighAttack.NextAttackTime)
        {
            if (UserInput.instance.playerController.InGame.Attack.triggered && jumping.IsGrounded == false && holdAndThrow.Estado != "Segurando")
            {
                AttackSoundAndDelay();
                animator.SetTrigger("Attack");
                InvokeRepeating(nameof(Attack), .064f, .016f);
                Invoke(nameof(AttackCooldown), .16f);
            }
            /*else if ((Input.GetKeyDown(attackButton) || Input.GetButtonDown("AttackJoystick")) && moving.isMoving == true && holdAndThrow.Estado != "Segurando")
            {
                AttackSoundAndDelay();
                animator.SetTrigger("Attack");
                InvokeRepeating(nameof(Attack), .216f, .016f);
                Invoke(nameof(AttackCooldown), .368f);
            }
            */
            else if (UserInput.instance.playerController.InGame.Attack.triggered && holdAndThrow.Estado != "Segurando")
            {
                AttackSoundAndDelay();
                animator.SetTrigger("Attack");
                InvokeRepeating(nameof(Attack), .096f, .016f);
                Invoke(nameof(AttackCooldown), .176f);
            }
        }

    }

    void Attack()
    {
        if (jumping.IsGrounded == false)
        {
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(JumpingAttackPoint.position, JumpingAttackRange, EnemyLayers);

            foreach (Collider2D enemy in HitEnemies)
            {
                Debug.Log("Inimigo tomou dano por ataque pulando.");

                if (enemy.tag == "Enemies" || enemy.tag == "Fly_Enemy" || enemy.tag == "Octoshooter")
                {

                    enemy.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
                }
                else if (enemy.tag == "Boss")
                {
                    enemy.GetComponent<BossScript>().takeDamageBySword(10);
                }



                AttackCooldown();
            }
            
        }
        else
        {
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            foreach (Collider2D enemy in HitEnemies)
            {
               // Debug.Log("Inimigo tomou dano.");
                if(enemy.tag == "Enemies" || enemy.tag == "Fly_Enemy" || enemy.tag == "Octoshooter")
                {
                    
                    enemy.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
                }
                else if(enemy.tag == "Boss")
                {
                    enemy.GetComponent<BossScript>().takeDamageBySword(10);
                }
                else if(enemy.tag == "PoisonCure")
                {
                   enemy.GetComponent<LeverPoisonCure>().ActivateEvent();
                }
                    
                
                    
                
                AttackCooldown();
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
        Gizmos.DrawWireSphere(JumpingAttackPoint.position, JumpingAttackRange);
    }
    public void AttackSoundAndDelay()
    {
        //Sound settings
        int i = Random.Range(1, 3);
        float randomPitch = Random.Range(.9f, 1.1f);
        swordSounds.pitch = randomPitch;
        attackSound = Resources.Load("sword_swing_" + i) as AudioClip;
        swordSounds.PlayOneShot(attackSound);
        NextAttackTime = Time.time + 1f / AttackRate;
    }
    void AttackCooldown()
    {
        CancelInvoke(nameof(Attack));
    }
}