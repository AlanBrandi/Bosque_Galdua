using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject item;
    public EnemiesScript enemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.currentHealth <= 0)
        {
           // Instantiate(item, transform.position, Quaternion.identity);
        }
    }
    
}
