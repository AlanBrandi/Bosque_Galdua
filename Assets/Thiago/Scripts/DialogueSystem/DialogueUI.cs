using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private UIAnimation anim;

    public bool isOpen { get; private set; }

    private ResponseHadler responseHadler;
    private TypewriterEffect typewriterEffect;
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHadler = GetComponent<ResponseHadler>();

      //  CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughtDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHadler.AddResponseEvents(responseEvents);
    }

    LTDescr tween = null;
    LTDescr tweenS = null;
    LTDescr tweenArrowAlpha = null;
    LTDescr tweenArrowScale = null;
    private IEnumerator StepThroughtDialogue(DialogueObject dialogueObject)
    {
        anim.dialogueOpen();
        LeanTween.alphaCanvas(anim.arrowActivator.GetComponent<CanvasGroup>(), 0f, .3f).setEaseInQuad();
        LeanTween.alphaCanvas(anim.talk.GetComponent<CanvasGroup>(), 0f, .3f).setEaseInQuad();
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            if (i == dialogueObject.Dialogue.Length - 1)
            {
                LeanTween.cancel(anim.arrows.gameObject);
                LeanTween.alphaCanvas(anim.arrows.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();

                if (anim.icon && tween != null)
                {
                    LeanTween.cancel(anim.icon.gameObject);
                }
                LeanTween.alphaCanvas(anim.icon.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();

                if (anim.icon && tweenS != null)
                {
                    tweenS.cancel(anim.icon.gameObject);
                }
                LeanTween.scale(anim.icon, new Vector3(1f, 1f, 1f), .2f).setEaseInOutQuad();
            }
            else if (i < dialogueObject.Dialogue.Length - 1)
            {
                if (anim.arrows && tweenArrowAlpha != null)
                {
                    LeanTween.cancel(anim.arrows.gameObject);
                }
                LeanTween.alphaCanvas(anim.arrows.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();

                if (anim.arrows && tweenArrowScale != null)
                {
                    tweenArrowScale.cancel(anim.arrows.gameObject);
                }
                LeanTween.scale(anim.arrows, new Vector3(1f, 1f, 1f), .2f).setEaseInOutQuad();
            }


            string dialogue = dialogueObject.Dialogue[i];

            yield return runTypingEffect(dialogue);

            textLabel.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;


            if (i == dialogueObject.Dialogue.Length - 1)
            {
                LeanTween.scale(anim.arrows, new Vector3(1f, 1f, 1f), .2f).setEaseInOutQuad();

                LeanTween.alphaCanvas(anim.icon.GetComponent<CanvasGroup>(), .7f, .5f).setEaseInQuad().setOnComplete(() =>
                {
                    tween = LeanTween.alphaCanvas(anim.icon.GetComponent<CanvasGroup>(), 0.3f, 0.5f).setEaseInQuad().setLoopPingPong();
                });

                tweenS = LeanTween.scale(anim.icon, new Vector3(.9f, .9f, .9f), .5f).setEaseInOutQuad().setLoopPingPong();
            }
            else if (i < dialogueObject.Dialogue.Length - 1)
            {
                LeanTween.alphaCanvas(anim.arrows.GetComponent<CanvasGroup>(), .7f, .5f).setEaseInQuad().setOnComplete(() =>
                {
                    tweenArrowAlpha = LeanTween.alphaCanvas(anim.arrows.GetComponent<CanvasGroup>(), 0.3f, 0.5f).setEaseInQuad().setLoopPingPong();
                });


                tweenArrowScale = LeanTween.scale(anim.icon, new Vector3(.9f, .9f, .9f), .5f).setEaseInOutQuad().setLoopPingPong();
            }

            yield return new WaitForSeconds(.5f);
            yield return new WaitUntil(() => UserInput.instance.playerController.InGame.Interact.triggered);
        }

        if (dialogueObject.HasResponses)
        {
            responseHadler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            tween.cancel(anim.icon.gameObject);
            tweenS.cancel(anim.icon.gameObject);
            CloseDialogueBox();
            anim.dialogueClose();
            
        }
    }

    private IEnumerator runTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.isRunning)
        {
            yield return null;

            if (UserInput.instance.playerController.InGame.Interact.triggered)
            {
                typewriterEffect.typewriterSpeed = 100f;
                typewriterEffect.isFaster = true;
            }
        }

    }

    public void CloseDialogueBox()
    {
        textLabel.text = string.Empty;
        StartCoroutine(dialogueBoxFadeOut());
    }
    private IEnumerator dialogueBoxFadeOut()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.alphaCanvas(anim.arrowActivator.GetComponent<CanvasGroup>(), 1f, .3f).setEaseInQuad();
        LeanTween.alphaCanvas(anim.talk.GetComponent<CanvasGroup>(), 1f, .3f).setEaseInQuad();
        isOpen = false;
        dialogueBox.SetActive(false);

    }
    
}
