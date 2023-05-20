using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool isOpen { get; private set; }

    private ResponseHadler responseHadler;
    private TypewriterEffect typewriterEffect;
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHadler = GetComponent<ResponseHadler>();

        CloseDialogueBox();
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

    private IEnumerator StepThroughtDialogue(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(.5f);
        for(int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return runTypingEffect(dialogue);

            textLabel.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => UserInput.instance.playerController.InGame.Debug_E.triggered);
        }

        if (dialogueObject.HasResponses)
        {
            responseHadler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }        
    }

    private IEnumerator runTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.isRunning)
        {
            yield return null;

            if (UserInput.instance.playerController.InGame.Debug_E.triggered)
            {
                typewriterEffect.typewriterSpeed = 100f;
            }
        }

    }

    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
