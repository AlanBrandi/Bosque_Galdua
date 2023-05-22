using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<knockbackPlayer>();
        if (player != null)
        {
            player.knockback();
        }
 
    }
}
