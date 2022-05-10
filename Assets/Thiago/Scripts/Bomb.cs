using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombSpeed;
    public Vector2 direction;
    public float splashRange;

    private void Start()
    {
        
        GetComponent<Rigidbody2D>().AddForce(direction * bombSpeed, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(splashRange > 0)
        {
            var hitcollider = Physics2D.OverlapCircleAll(transform.position, splashRange);
        }

        if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

}