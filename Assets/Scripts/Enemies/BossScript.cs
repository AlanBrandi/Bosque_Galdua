using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript: MonoBehaviour
{
    public int maxHealth = 20;
    public int dano;

    
    
    public int BosscurrentHealth;
    
    
    MyHealthSystem myHealthSystem;
    
    Rigidbody2D rb;
    public Boss boss;

    //public GameObject monster;
    void Start()
    {
        myHealthSystem = GameObject.FindObjectOfType<MyHealthSystem>();       
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        boss.healthBar.value = BosscurrentHealth;
        
    }

  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dano > 0 && boss.CanTakeDamage)
        {
            Debug.Log("Inimigo deu dano em player.");
            myHealthSystem.Dano(dano);
        }
    }

  
    public void TakeDamageByItem(int damage)
    {
        boss.shake1();
            BosscurrentHealth -= damage;
            if (BosscurrentHealth > 16)
            {
                boss.anim.SetTrigger("Hurt");
            }

        

        if (BosscurrentHealth <= 16)
        {
            boss.anim.SetTrigger("Die");
        }

    }
    public void takeDamageBySword(int damage)
    {
        if (boss.anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSlam"))
        {
            boss.shake1();
            BosscurrentHealth -= damage;
            if (BosscurrentHealth > 16)
            {
                boss.anim.SetTrigger("HurtSlam");
            }
        }

        if (BosscurrentHealth <= 16)
        {
            boss.anim.SetTrigger("Die");
        }
    }

}
