using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesScript : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //hurt animation
        Debug.Log("damage!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //animation die
        Debug.Log("Enemy Died");
    }
}
