using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectable : MonoBehaviour
{
    [SerializeField] private GameObject fx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().canWallJump = true;
            Instantiate(fx, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
