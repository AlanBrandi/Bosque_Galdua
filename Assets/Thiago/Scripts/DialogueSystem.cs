using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public  TMP_Text NpcName;
    public TMP_Text MessageText;
    public RectTransform Backgroundbox;
    public static bool isActive = false;
    public GameObject playerManager;

    Message[] currentMessages;
    Npc[] currentNpcs;
    int activateMessage = 0;

    public void OpenDialogue(Message[] messages, Npc[] npcs)
    {
        

        currentMessages = messages;
        currentNpcs = npcs;
        activateMessage = 0;

        isActive = true;

        DisplayMessage();
        playerManager.GetComponent<Moving>().enabled = false;
        playerManager.GetComponent<PlayerAttack>().enabled = false;
        playerManager.GetComponent<PlayerHighAttack>().enabled = false;
        playerManager.GetComponent<Jumping>().enabled = false;

    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activateMessage];
        MessageText.text = messageToDisplay.message;

        Npc npcToDisplay = currentNpcs[messageToDisplay.npcId];
        NpcName.text = npcToDisplay.name;
    }

    public void NextMessage()
    {
        activateMessage++;
        if(activateMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isActive = false;
            this.gameObject.SetActive(false);
            playerManager.GetComponent<Moving>().enabled = true;
            playerManager.GetComponent<PlayerAttack>().enabled = true;
            playerManager.GetComponent<PlayerHighAttack>().enabled = true;
            playerManager.GetComponent<Jumping>().enabled = true;
            activateMessage = 0;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }


}
