using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInside : MonoBehaviour
{
    Animator MyAnimator;
    bool IsPlayerInside = false;

    private void Start()
    {
        MyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MyAnimator.SetBool("Playerinside", true);
            IsPlayerInside = true;
        }
    }
}