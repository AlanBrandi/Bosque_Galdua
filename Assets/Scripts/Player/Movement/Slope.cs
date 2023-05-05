using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    /*
    Jumping jump;
    Moving move;

    LayerMask groundLayer;
    Transform feetPos;

    Vector2 checkPos;
    Vector2 slopeNormalPerp;

    public float maxSlopeAngle;
    public float slopeCheckDistance;
    public float checkRadius;
    public float slopeDownAngle;
    float slopeDownAngleOld;
    float slopeSideAngle;

    public bool isOnSlope;
    bool isGrounded;
    bool canWalkOnSlope;

    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D FullFriction;

    Rigidbody2D rb;

    
    private void Start()
    {
        feetPos = GameObject.Find("FeetPos").transform;
        groundLayer = LayerMask.GetMask("Ground");
        jump = GetComponent<Jumping>();
        move = GetComponent<Moving>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);
        SlopeCheck();
        ApplyMovement();
    }
    void SlopeCheck()
    {
        checkPos = new Vector2(feetPos.position.x, feetPos.position.y);
        SlopeCheckHorizontal(checkPos);
        SlopeCheckVentical(checkPos);
    }

    void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, groundLayer);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, groundLayer);

            if (slopeHitFront)
            {
                isOnSlope = true;
                slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
            }
            else if (slopeHitBack)
            {
                isOnSlope = true;
                slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
            }
            else
            {
                slopeSideAngle = 0.0f;
                isOnSlope = false;
            }

    }
    void SlopeCheckVentical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, groundLayer);
        if (hit)
        {
            
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if(slopeDownAngle != 0 || slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = false;
            }
            else
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }

        if (slopeDownAngle > maxSlopeAngle || slopeSideAngle > maxSlopeAngle)
        {
            canWalkOnSlope = false;
        }
        else
        {
            canWalkOnSlope = true;
        }
        if(isOnSlope && move.hor == 0.0f && canWalkOnSlope)
        {
            rb.sharedMaterial = FullFriction;
        }
        else
        {
            rb.sharedMaterial = noFriction;
        }
    }

    void ApplyMovement()
    {
        if(isGrounded && isOnSlope && jump.isJumping == false && canWalkOnSlope)
        {
            rb.velocity = new Vector2(move.speed * slopeNormalPerp.x * -move.hor, move.speed * slopeNormalPerp.y * -move.hor);
        }
    }
    */
}
