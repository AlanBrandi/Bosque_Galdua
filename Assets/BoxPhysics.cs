using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhysics : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Debug.Log("Oi");
        if (rb.velocity.y > 0)
        {
            rb.mass = 100;
        }
    }
}