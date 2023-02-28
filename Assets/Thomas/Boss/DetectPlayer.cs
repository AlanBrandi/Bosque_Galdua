using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool playerIsHere = false;
    public Boss boss;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("PLAYER IS HERE");
            boss.CanTakeDamage = false;
            playerIsHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("PLAYER IS OUT");            
            if (!boss.anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSlam"))
            {
                boss.CanTakeDamage = true;
            }
            playerIsHere = false;

        }
    }
}
