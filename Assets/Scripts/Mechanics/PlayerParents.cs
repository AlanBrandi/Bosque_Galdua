using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParents : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D FullFriction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.sharedMaterial = FullFriction;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.sharedMaterial = noFriction;
        }
    }
}
