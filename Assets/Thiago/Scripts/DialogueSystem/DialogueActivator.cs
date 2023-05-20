using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interectible
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private UIAnimation anim;

    public void UpdateDialogueObejct(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerDialogue player))
        {
            player.interectible = this;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerDialogue player))
        {
            if (player.interectible is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.interectible = null;
            }
        }
    }
    public void Interect(PlayerDialogue player)
    {
        foreach(DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if(responseEvents.DialogueObject == dialogueObject)
            {
               player.DialogueUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }
        anim.dialogueOpen();
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
