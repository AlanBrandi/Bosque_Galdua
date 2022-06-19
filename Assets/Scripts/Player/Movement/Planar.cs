using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planar : MonoBehaviour
{
    public KeyCode thiskey;
    Rigidbody2D rb;
    Transform feetPos;
    Transform frontCheck;
    public float checkRadius;
    LayerMask groundLayer;
    public bool isTouchingFront;
    public float glindSpeed;
    public float initialGravityScale;
    public bool wallSliding;
    public bool IsGrounded;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        frontCheck = GameObject.Find("FrontCheck").transform;
        feetPos = GameObject.Find("FeetPos").transform;
        animator = GetComponentInChildren<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponentInChildren<Rigidbody2D>();
        initialGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, groundLayer);

        if (isTouchingFront == true && IsGrounded == false && input != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (IsGrounded == false && wallSliding == false && Input.GetKey(thiskey) || Input.GetButtonUp("JumpJoystick") && rb.velocity.y <= 0)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, y: -glindSpeed);
        }
        else
        {
            rb.gravityScale = initialGravityScale;
        }

        if (IsGrounded == true)
        {
            animator.SetBool("IsJumping", false);
            rb.gravityScale = initialGravityScale;
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
    }
}
