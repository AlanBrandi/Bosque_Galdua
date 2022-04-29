using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAutoMove : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public float speed = 1;
    Transform MyTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }
}
