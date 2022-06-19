using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumping : MonoBehaviour
{
    public float checkRadius;
    LayerMask groundLayer;
    LayerMask wallLayer;
    public bool IsGrounded;
    Rigidbody2D rb;
    GameObject player;
    public bool isTouchingFront;
    Transform frontCheck;
    Transform feetPos;
    public bool wallSliding;
    public float wallSlidingSpeed;
    //bool wallJumping; Not currently being used
    public Vector2 wallJumpDirection;
    public float wallJumpForce;
    Moving moveScript;
    public float input;

    private void Start()
    {
        wallLayer = LayerMask.GetMask("Wall");
        frontCheck = GameObject.Find("FrontCheck").transform;
        feetPos = GameObject.Find("FeetPos").transform;
        rb = GetComponentInChildren<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        groundLayer = LayerMask.GetMask("Ground");
        moveScript = GetComponent<Moving>();
    }


    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, wallLayer);

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);

        if (isTouchingFront && !IsGrounded && rb.velocity.y < 0 && input != 0)
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

        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonUp("JumpJoystick") && wallSliding)
        {
            Vector2 force = new Vector2(wallJumpForce * wallJumpDirection.x * -input, wallJumpForce * wallJumpDirection.y);

            rb.velocity = Vector2.zero;

            rb.AddForce(force, ForceMode2D.Impulse);

            StartCoroutine("stopMove");
           
        }

    }
    IEnumerator stopMove()
    {
        moveScript.canMove = false;

        Quaternion back = player.transform.rotation;

        if(input > 0)
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(input < 0)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        

        yield return new WaitForSeconds(0.3f);

        

        moveScript.canMove = true;
    }

    /*void SetWallJumpingToFalse() - Not currently being used
    {
        wallJumping = false;
      
    }*/
}
