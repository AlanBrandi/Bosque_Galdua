using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackPlayer : MonoBehaviour
{
    public Transform center;
    public float knockbackTime;
    private bool knockbacked;
    private PlayerMovement move;
    private float coolDownTime = 1f;
    private float coolDown = 0f;
    private bool canCoolDowm;

    public float forceX;
    public float forceY;

    private void Start()
    {
        coolDown = 0f;
    }
    private void Update()
    {
        if (canCoolDowm)
        {
            coolDown += Time.deltaTime;
        }
        if (coolDown >= coolDownTime)
        {
            coolDown = 0;
            canCoolDowm = false;
        }
    }
    public void knockback()
    {
        if (coolDown <= 0 && !canCoolDowm)
        {
            canCoolDowm = true;
            move = GetComponent<PlayerMovement>();
            move.RB.velocity = Vector2.zero;
            move.canMove = false;

            Vector2 force = new Vector2(forceX, forceY);
            if (!move.IsFacingRight)
            {
                force.x *= 1;
            }
            else
            {
                force.x *= -1;
            }                       

            if (Mathf.Sign(move.RB.velocity.x) != Mathf.Sign(force.x))
                force.x -= move.RB.velocity.x;

            if (move.RB.velocity.y < 0)
                force.y -= move.RB.velocity.y;

            move.RB.AddForce(force, ForceMode2D.Impulse);
            StartCoroutine(Unknockback());
            knockbacked = true;
        }
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        move.canMove = true;
        knockbacked = false;
    }
}
