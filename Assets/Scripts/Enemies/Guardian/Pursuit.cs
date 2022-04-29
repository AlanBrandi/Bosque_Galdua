using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 targetPosition;
    Vector2 direction;
    Vector2 velocity;

    public float speed = 5;

    Vector2 target_velocity;
    Vector2 steer_velocity;
    public float mass = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        targetPosition = player.transform.position;
        direction = ((Vector3)targetPosition - transform.position).normalized;
        target_velocity = direction * speed;
        steer_velocity = target_velocity - velocity;
        steer_velocity = steer_velocity / mass;
        velocity += steer_velocity;
        Rotate();
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

}
