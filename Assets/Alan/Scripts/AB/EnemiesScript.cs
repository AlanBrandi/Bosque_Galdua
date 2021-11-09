using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesScript : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public GameObject fxDie;
    public GameObject fxHit;
    public Transform whereToAddEffect;
    Transform customWhereToAdd;
    //public GameObject monster;
    void Start()
    {
        currentHealth = maxHealth;
        // monster = this.GetComponent<GameObject>();
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
        Debug.Log("damage!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(fxDie, whereToAddEffect.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
