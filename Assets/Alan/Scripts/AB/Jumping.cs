using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Rigidbody2D MyRb;
    public KeyCode thiskey;
    public bool IsGrounded;
    public Animator MyAni;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisground;
    public LayerMask slopeground;
    public float jumpForce;
    float jumpTimeCounter;
    public float JumpTime;
    public bool isJumping = false;
    public Slope slop;
    public AudioSource jumpSound;
    public AudioSource LandSound;
    public Rigidbody2D rb;
    public float glindSpeed;
    public float initialGravityScale;


    private void Start()
    {
        initialGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        

        if (IsGrounded == false && Input.GetKey(thiskey) && rb.velocity.y <= 0)
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

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        if (IsGrounded == true && Input.GetKeyDown(thiskey) && slop.slopeDownAngle <= slop.maxSlopeAngle)
        {
            //MyAni.SetBool("IsJumping", true);
            isJumping = true;
            jumpTimeCounter = JumpTime;
            MyRb.AddForce(Vector2.up * jumpForce);
        }
        //----------------------------------------------------

        if (Input.GetKey(thiskey) && isJumping == true)
        {
            jumpSound.Play();
            if (jumpTimeCounter > 0)
            {
                MyRb.AddForce(Vector2.up * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            { 
                isJumping = false;
            }
        }

        //----------------------------------------------------
        if (Input.GetKeyUp(thiskey))
        {
            isJumping = false;
        }
    }
}
