using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Rigidbody2D MyRb;
    public KeyCode thiskey;
    public KeyCode DownPlatform;
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
//<<<<<<< HEAD
    public Rigidbody2D rb;
    public float glindSpeed;
    public float initialGravityScale;
    public bool isTouchingFront;
    public Transform frontCheck;
    public bool wallSliding;
    public float wallSlidingSpeed;
    bool wallJumping;
    public float XjumpWallForce;
    public float YjumpWallForce;
    public float wallJumpTime;


    private void Start()
    {
        initialGravityScale = rb.gravityScale;
    }
//=======
    public PlatformEffector2D Platform;
//>>>>>>> b0b5100dbaec50bf564d7bf86e37196dacd91486

    private void Update()
    {
        

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

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        if (IsGrounded == true && Input.GetKeyDown(thiskey) && slop.slopeDownAngle <= slop.maxSlopeAngle)
        {
            //MyAni.SetBool("IsJumping", true);
            isJumping = true;
            jumpTimeCounter = JumpTime;
            MyRb.AddForce(Vector2.up * jumpForce);
        }
        //----------------------------------------------------

        float input = Input.GetAxisRaw("Horizontal");

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatisground);

        if(isTouchingFront == true && IsGrounded == false && input != 0)
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

        if(Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(XjumpWallForce * -input, YjumpWallForce);
        }
       

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
//<<<<<<< HEAD
        
    }
    void SetWallJumpingToFalse()
    {
        wallJumping = false;
//=======

//>>>>>>> b0b5100dbaec50bf564d7bf86e37196dacd91486
    }
}
