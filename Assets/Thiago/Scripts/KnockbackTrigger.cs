using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<knockbackPlayer>();
        var enemy = other.collider.GetComponent<EnemiesScript>();
        if (player != null)
        {
            player.knockback(transform);
        }
        
        if(enemy != null)
        {
           // enemy.knockback(transform);
        }
    }
}
