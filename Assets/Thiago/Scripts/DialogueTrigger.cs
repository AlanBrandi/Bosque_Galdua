using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Npc[] npcs;
    public GameObject triggerbox;
    public GameObject messagebox;


    public void StartDialogue()
    {
        FindObjectOfType<DialogueSystem>().OpenDialogue(messages, npcs);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            triggerbox.SetActive(false);
            messagebox.SetActive(true);
            StartDialogue();

            

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerbox.SetActive(true);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
            triggerbox.SetActive(false);
        
    }

}
    

    [System.Serializable]
    public class Message
    {
        public int npcId;
        public string message;
    }

    [System.Serializable]
    public class Npc
    {
        public string name;
    }

    

