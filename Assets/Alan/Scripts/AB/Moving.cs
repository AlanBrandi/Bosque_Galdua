using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Animator MyAnimator;
    public GameObject Player;
    public Rigidbody2D rb;
    public float hor;
    public float speed = 1;
    internal bool isMoving = false;
    public AudioSource footstep;
    Jumping jumpScript;
    public bool canMove = true;

    private void Start()
    {
        footstep.pitch = 1;
        jumpScript = GetComponent<Jumping>();
    }
    private void FixedUpdate()
    {
        Move();

        MyAnimator.SetFloat("Speed", rb.velocity.magnitude);

        float randomPitch = Random.Range(0.8f, 1.5f);
        footstep.pitch = randomPitch;

        if (rb.velocity.x !=0 && jumpScript.IsGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!footstep.isPlaying)
                footstep.Play();
        }
        else
        {
            footstep.Stop();
        }

        
    }
    public void Move()
    {
        if (canMove)
        {
            hor = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(hor * speed, rb.velocity.y);

            if (hor > 0)
            {
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else if (hor < 0)
            {
                Player.transform.rotation = Quaternion.Euler(0, -180, 0);

            }
        }
    }

    public void stopMove()
    {
        canMove = false;
    }
}
