using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUi;
    public DialogueUI DialogueUI => dialogueUi;
    public Interectible interectible { get; set; }

    private PlayerMovement move;

    private void Start()
    {
        move = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Debug_E.triggered)
        {
            if (interectible != null && !dialogueUi.isOpen)
            {
                interectible.Interect(this);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interact"))
        {
            Debug.Log("AAAAAAAAAA");
            dialogueUi = other.GetComponentInChildren<DialogueUI>();
        }
    }

    private bool canMoveAgain;
    private void FixedUpdate()
    {
        if(dialogueUi != null)
        {
            if (dialogueUi.isOpen)
            {
                canMoveAgain = true;
                move.canMove = false;
            }
            else if (!dialogueUi.isOpen && canMoveAgain)
            {
                move.canMove = true;
                canMoveAgain = false;
            }
        }        
    }
}
