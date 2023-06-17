using HardLight2DUtil;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interectible
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private UIAnimation anim;

    private void Start()
    {
        tween = LeanTween.moveLocalY(anim.arrowActivator, 14f, 1f).setEaseInQuad().setLoopPingPong();
    }

    public void UpdateDialogueObejct(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }
    LTDescr tween;
    LTDescr tweenalpha1;
    LTDescr tweenalpha2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(anim.arrowActivator && tweenalpha1 != null)
            {
                LeanTween.cancel(tweenalpha1.uniqueId);
            }

            if (anim.talk && tweenalpha2 != null)
            {
                LeanTween.cancel(tweenalpha2.uniqueId);
            }

           // if (anim.arrowActivator && tween != null)
           // {
           //     LeanTween.cancel(anim.arrowActivator.gameObject);
          //  }

         //   Vector2 newPosition = anim.arrowActivator.GetComponent<RectTransform>().anchoredPosition;
         //   newPosition.y = 21f;
         //   anim.arrowActivator.GetComponent<RectTransform>().anchoredPosition = newPosition;


            anim.arrowActivator.GetComponent<CanvasGroup>().alpha = 0f;
            anim.talk.GetComponent<CanvasGroup>().alpha = 0f; 
            

            tweenalpha1 = LeanTween.alphaCanvas(anim.arrowActivator.GetComponent<CanvasGroup>(), 1f, .3f).setEaseInQuad();
            tweenalpha2 = LeanTween.alphaCanvas(anim.talk.GetComponent<CanvasGroup>(), 1f, .3f).setEaseInQuad();
           // tween = LeanTween.moveLocalY(anim.arrowActivator,14f, 1f).setEaseInQuad().setLoopPingPong();
        }
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerDialogue player))
        {
            player.interectible = this;           
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            anim.arrowActivator.GetComponent<CanvasGroup>().alpha = 1f;
            anim.talk.GetComponent<CanvasGroup>().alpha = 1f;

            tweenalpha1 = LeanTween.alphaCanvas(anim.arrowActivator.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
            tweenalpha2 = LeanTween.alphaCanvas(anim.talk.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();        
        }
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
       // tweenalpha1 = LeanTween.alphaCanvas(anim.arrowActivator.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
       // tweenalpha2 = LeanTween.alphaCanvas(anim.talk.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
