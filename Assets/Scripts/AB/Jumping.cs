using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Rigidbody2D MyRb;
    public KeyCode thiskey;
    bool IsGrounded;
    public Animator MyAni;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisground;
    public float jumpForce;
    float jumpTimeCounter;
    public float JumpTime;
    bool isJumping = false;

    private void Update()
    {
        if (IsGrounded == true)
        {
            MyAni.SetBool("IsJumping", false);
        }
        else
        {
            MyAni.SetBool("IsJumping", true);
        }

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);
        if (IsGrounded == true && Input.GetKeyDown(thiskey))
        {
            //MyAni.SetBool("IsJumping", true);
            isJumping = true;
            jumpTimeCounter = JumpTime;
            MyRb.velocity = Vector2.up * jumpForce;
        }
        //----------------------------------------------------

        if (Input.GetKey(thiskey) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                MyRb.velocity = Vector2.up * jumpForce;
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
