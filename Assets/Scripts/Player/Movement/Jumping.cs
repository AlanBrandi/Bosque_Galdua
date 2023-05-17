using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [Header("SoundFX")]
    public AudioSource jumpSound;

    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool isJumping = false;
   
    private Moving moveScript;
    private WallJumping wallJump;
    private Transform feetPos;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Set ground layer")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Jump variables")]
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkRadius;
    [SerializeField] private float JumpTime;


    private bool buttonHeld = false;
    private float holdTime = 0f;
    public float requiredHoldTime = 2f;

    private float coyoteTime = .2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = .15f;
    private float jumpBufferCount;

    private void Awake()
    {
        moveScript = GetComponent<Moving>();
        wallJump = GetComponent<WallJumping>();
        animator = GetComponentInChildren<Animator>();
        feetPos = GameObject.Find("FeetPos").transform;
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Jump.triggered)
        {
            jumpBufferCount = jumpBufferTime;
            buttonHeld = true;
            holdTime = 0f;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

        if (UserInput.instance.playerController.InGame.Jump.ReadValue<float>() <= 0)
        {
            buttonHeld = false;
        }


        if (buttonHeld)
        {
            holdTime += Time.deltaTime;

        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !buttonHeld)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            coyoteTimeCounter = 0;
        }


        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);
        if (IsGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            animator.SetBool("IsJumping", false);
            
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            if(coyoteTimeCounter <= 0)
            {
                animator.SetBool("IsJumping", true);
            }
            
        }
        if (coyoteTimeCounter > 0 == true && jumpBufferCount > 0f && !wallJump.wallSliding && moveScript.canMove)
        {
            jumpBufferCount = 0f;
            Jump();
        }
    }
    private void Jump()
    {
        isJumping = true;
        rb.velocity = Vector2.up * jumpForce;
        jumpSound.Play();
    }

}
