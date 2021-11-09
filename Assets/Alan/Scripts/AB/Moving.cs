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

    
    private void FixedUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(hor * speed, rb.velocity.y);

        if(hor > 0)
        {
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (hor < 0)
        {
            Player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        MyAnimator.SetFloat("Speed", rb.velocity.magnitude);
    }
}
