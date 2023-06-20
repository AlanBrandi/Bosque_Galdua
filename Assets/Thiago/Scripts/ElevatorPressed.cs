using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPressed : MonoBehaviour
{
    private Animator anim;
    private bool canActivate = true;
    private bool firstTouch = true;

    public bool isPuzzle;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && canActivate)
        {
            if (isPuzzle)
            {
                if (firstTouch)
                {
                    StartCoroutine(activatePuzzle());
                }
            }
            else
            {
                StartCoroutine(activate());
            }
            
            
        }
    }
    IEnumerator activatePuzzle()
    {
        yield return new WaitForSeconds(.25f);
        firstTouch = false;
        anim.SetTrigger("DOWN");
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(upPuzzle());
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
    IEnumerator upPuzzle()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("UP");
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(downPuzzle());


    }
    IEnumerator downPuzzle()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("DOWN");
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(upPuzzle());


    }
}
