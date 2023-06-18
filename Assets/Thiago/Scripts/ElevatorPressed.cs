using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPressed : MonoBehaviour
{
    private Animator anim;
    private bool canActivate = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && canActivate)
        {
            StartCoroutine(activate());
        }
    }

    IEnumerator activate()
    {
        yield return new WaitForSeconds(.25f);
        canActivate = false;
        anim.SetTrigger("UP");
        StartCoroutine(down());
    }

    IEnumerator down()
    {
        yield return new WaitForSeconds(6f);
        anim.SetTrigger("DOWN");
        yield return new WaitForSeconds(3f);
        canActivate = true;


    }
}
