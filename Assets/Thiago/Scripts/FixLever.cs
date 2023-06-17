using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixLever : MonoBehaviour
{
    public bool canFix = false;
    public GameObject newLever;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canFix)
        {
            newLever.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
