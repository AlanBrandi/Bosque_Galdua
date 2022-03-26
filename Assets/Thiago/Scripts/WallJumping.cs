using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumping : MonoBehaviour
{
    public float checkRadius;
    public LayerMask whatisground;
    public bool IsGrounded;
    public Rigidbody2D rb;
    public bool isTouchingFront;
    public Transform frontCheck;
    public Transform feetPos;
    public bool wallSliding;
    public float wallSlidingSpeed;
    bool wallJumping;
    public float XjumpWallForce;
    public float YjumpWallForce;
    public float wallJumpTime;

  

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatisground);

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        if (isTouchingFront == true && IsGrounded == false && input != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(XjumpWallForce * -input, YjumpWallForce);

            //transform.Translate(new Vector2(-input, 0F) * XjumpWallForce * Time.deltaTime);
           // transform.Translate(new Vector2(0F, YjumpWallForce));
           // flip();
        }
        void flip()
        {
            input *= -1;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
    }

    
    void SetWallJumpingToFalse()
    {
        wallJumping = false;
      
    }
}
