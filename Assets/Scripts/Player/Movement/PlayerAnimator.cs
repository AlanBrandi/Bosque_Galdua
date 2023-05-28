using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement mov;
    public Animator anim;
   // private SpriteRenderer spriteRend;


    [Header("Particle FX")]
    [SerializeField] private GameObject jumpFX;
    [SerializeField] private GameObject landFX;
    public GameObject turnFX;
    public GameObject WallJumpFX;
    public GameObject slideFX;
    public GameObject boxFX;
    public Transform pos;
    public Transform boxPos;
    public Transform slidePos;

    private Rigidbody2D rb;

    public bool startedJumping {  private get; set; }
    public bool justLanded { private get; set; }

    public float currentVelY;

    private void Start()
    {
        mov = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (mov.CanJump())
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsSliding", false);
        }
        else if (!mov.CanJump() && !mov.IsSliding)
        {
            anim.SetBool("IsJumping", true);
        }

        if (mov.IsSliding && !mov.CanJump())
        {
           // anim.SetBool("IsSliding", true);
        }
        else if(!mov.IsSliding || mov.CanJump())
        {
            
        }

        if (mov.CanWallJump())
        {
           // anim.SetBool("IsJumping", false);
        }

        if(mov.CanWallJump() && mov.LastPressedJumpTime > 0)
        {
            GameObject obj = Instantiate(jumpFX, pos.transform.position, Quaternion.Euler(-90, -180, 90));
            Destroy(obj, 1);
        }
    }

    private void LateUpdate()
    {   
        CheckAnimationState();
    }

    private void CheckAnimationState()
    {
        if (startedJumping)
        {
            GameObject obj = Instantiate(jumpFX, pos.transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 1);
            startedJumping = false;
            return;
        }

        if (justLanded)
        {
            GameObject obj = Instantiate(landFX, pos.transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 1);
            justLanded = false;
            return;
        }
    }
    public void deativateWallJumpAnim()
    {
        anim.SetBool("WallJump", false);
    }
}
