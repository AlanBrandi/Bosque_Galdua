using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody2D rb;
    public KeyCode thiskey;
    public KeyCode DownPlatform;
    public bool IsGrounded;
    Animator animator;
    Transform feetPos;
    public float checkRadius;
    LayerMask groundLayer;
    public float jumpForce;
    double jumpTimeCounter;
    public float JumpTime;
    public bool isJumping = false;
    Slope slope;
    public AudioSource jumpSound;
    //public AudioSource LandSound; - Not currently being used



    //=======
    //>>>>>>> b0b5100dbaec50bf564d7bf86e37196dacd91486

    private void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        animator = GetComponentInChildren<Animator>();
        feetPos = GameObject.Find("FeetPos").transform;
        slope = GetComponent<Slope>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {  
        if (IsGrounded == true)
        {
            animator.SetBool("IsJumping", false);
            
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);

        if ((IsGrounded == true && Input.GetKeyDown(thiskey) || Input.GetButtonDown("JumpJoystick")) && slope.slopeDownAngle <= slope.maxSlopeAngle)
        {
            //MyAni.SetBool("IsJumping", true);
            isJumping = true;
            jumpTimeCounter = JumpTime;
            rb.AddForce(Vector2.up * jumpForce);
        }
        //----------------------------------------------------

       
       
        if ((Input.GetKeyDown(thiskey) || Input.GetButtonDown("JumpJoystick")) && isJumping == true)
        {
            jumpSound.Play();
        }

        if ((Input.GetKeyDown(thiskey) || Input.GetButtonDown("JumpJoystick")) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumpTimeCounter -= Time.fixedDeltaTime;
            }
            else
            { 
                isJumping = false;
            }
        }

        //----------------------------------------------------
        if (Input.GetKeyUp(thiskey) || Input.GetButtonUp("JumpJoystick"))
        {
            isJumping = false;
        }
//<<<<<<< HEAD
        
    }

}
