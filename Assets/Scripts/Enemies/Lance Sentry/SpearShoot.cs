using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearShoot : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRb;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRb.velocity = new Vector2(moveDir.x, moveDir.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            bulletRb.velocity = Vector2.zero;
        }
    }
}
