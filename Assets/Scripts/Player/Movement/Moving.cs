using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private Rigidbody2D rb;

    [Header("Speed configuration")]
    [SerializeField] private float speed = 1;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool isMoving = false;

    private float moveInput;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", rb.velocity.magnitude);
        Move();
    }
    private void Move()
    {
        moveInput = UserInput.instance.moveInput.x;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        isMoving = true;
        if (moveInput > 0)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
    public void stopMove()
    {
        canMove = false;
    }
}
