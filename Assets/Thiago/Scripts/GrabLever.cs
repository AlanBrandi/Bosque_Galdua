using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLever : MonoBehaviour
{
    public FixLever leverGrab;
    public DialogueActivator dialogueDelete;
    public Animator anim;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && UserInput.instance.playerController.InGame.Interact.triggered)
        {
            if (anim != null)
            {
                anim.SetTrigger("OPEN");
            }
            
            Destroy(dialogueDelete);
            leverGrab.canFix = true;
            Destroy(this.gameObject);
        }
    }
}
