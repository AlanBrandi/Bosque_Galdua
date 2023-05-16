using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleFlip : MonoBehaviour
{
    [SerializeField] private bool facingRight = true;
    private float playerDirection;
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        FlipsTowardsPlayer();
    }

    void Flip()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = false;

        }
        else if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = true;
        }

    }
    void FlipsTowardsPlayer()
    {
        playerDirection = target.transform.position.x - transform.position.x;

        if (playerDirection < 0 && facingRight)
        {

            Flip();
        }
        else if (playerDirection > 0 && !facingRight)
        {
            Flip();
        }
    }
}
