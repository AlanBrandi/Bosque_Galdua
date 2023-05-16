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

    public bool canMove = true;
    [HideInInspector] public bool isMoving = false;

    private float moveInput;

    [SerializeField] private float acceleration = 10f; 
   
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        Move();
    }
    private void Move()
    {
        if (canMove)
        {
            float currentSpeed = rb.velocity.x;
            moveInput = UserInput.instance.moveInput.x;

            if (Mathf.Abs(moveInput) > 0.1f) 
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, moveInput * speed, acceleration * Time.deltaTime);
            }
            else 
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.deltaTime);
            }

            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            isMoving = Mathf.Abs(currentSpeed) > 0.1f;
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
    }
    public void stopMove()
    {
        canMove = false;
    }
}
