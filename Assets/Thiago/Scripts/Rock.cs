using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private PlayerHealth live;
    public GameObject explosionEffect;

    private void Start()
    {
        live = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            //live.Hit(2);
            
        }
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);


    }
}
