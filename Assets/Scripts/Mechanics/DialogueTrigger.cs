using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Npc[] npcs;
    public GameObject triggerbox;
    public GameObject messagebox;
    bool playerInRange = false;
    

    public void StartDialogue()
    {
        FindObjectOfType<DialogueSystem>().OpenDialogue(messages, npcs);
        

    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && playerInRange == true)
        {


            triggerbox.SetActive(false);
            messagebox.SetActive(true);
            StartDialogue();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerbox.SetActive(false);
            messagebox.SetActive(false);
            playerInRange = false;
        }
        
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerbox.SetActive(true);
            playerInRange = true;
        }
        
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

    

