using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLever : MonoBehaviour
{
    public FixLever leverGrab;
    public DialogueActivator dialogueDelete;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && UserInput.instance.playerController.InGame.Debug_E.triggered)
        {
            Destroy(dialogueDelete);
            leverGrab.canFix = true;
            Destroy(this.gameObject);
        }
    }
}
