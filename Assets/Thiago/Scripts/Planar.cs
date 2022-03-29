using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planar : MonoBehaviour
{
    public KeyCode thiskey;
    public Rigidbody2D rb;
    public Transform feetPos;
    public Transform frontCheck;
    public float checkRadius;
    public LayerMask whatisground;
    public bool isTouchingFront;
    public float glindSpeed;
    public float initialGravityScale;
    public bool wallSliding;
    public bool IsGrounded;
    public Animator MyAni;

    // Start is called before the first frame update
    void Start()
    {
        initialGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatisground);

        if (isTouchingFront == true && IsGrounded == false && input != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (IsGrounded == false && wallSliding == false && Input.GetKey(thiskey) && rb.velocity.y <= 0)
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
            MyAni.SetBool("IsJumping", false);
            rb.gravityScale = initialGravityScale;
        }
        else
        {
            MyAni.SetBool("IsJumping", true);
        }
    }
}
