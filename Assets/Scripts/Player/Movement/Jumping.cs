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
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkRadius;
    [SerializeField] private float JumpTime;


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
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);
        if (IsGrounded)
        {
            animator.SetBool("IsJumping", false);
            
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        if (IsGrounded == true && UserInput.instance.playerController.InGame.Jump.triggered && !wallJump.wallSliding && moveScript.canMove)
        {
            Jump();
        }
    }
    private void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce);
        jumpSound.Play();
    }

}
