using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeversMessage : MonoBehaviour
{
    public GameObject talk;
    public GameObject arrowActivator;
    public bool canShowAgain = true;
    private void Start()
    {
        tween = LeanTween.moveLocalY(arrowActivator, 14f, 1f).setEaseInQuad().setLoopPingPong();
    }
    LTDescr tween;
    LTDescr tweenalpha1;
    LTDescr tweenalpha2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canShowAgain)
        {
            if (arrowActivator && tweenalpha1 != null)
            {
                LeanTween.cancel(tweenalpha1.uniqueId);
            }

            if (talk && tweenalpha2 != null)
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


            arrowActivator.GetComponent<CanvasGroup>().alpha = 0f;
            talk.GetComponent<CanvasGroup>().alpha = 0f;


            tweenalpha1 = LeanTween.alphaCanvas(arrowActivator.GetComponent<CanvasGroup>(), 1f, .3f).setEaseInQuad();
            tweenalpha2 = LeanTween.alphaCanvas(talk.GetComponent<CanvasGroup>(), 1f, .3f).setEaseInQuad();
            // tween = LeanTween.moveLocalY(anim.arrowActivator,14f, 1f).setEaseInQuad().setLoopPingPong();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canShowAgain)
        {


            arrowActivator.GetComponent<CanvasGroup>().alpha = 1f;
            talk.GetComponent<CanvasGroup>().alpha = 1f;

            tweenalpha1 = LeanTween.alphaCanvas(arrowActivator.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
            tweenalpha2 = LeanTween.alphaCanvas(talk.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canShowAgain)
        {
            if (UserInput.instance.playerController.InGame.Interact.triggered)
            {                
                arrowActivator.GetComponent<CanvasGroup>().alpha = 1f;
                talk.GetComponent<CanvasGroup>().alpha = 1f;

                LeanTween.cancel(tweenalpha1.uniqueId);
                LeanTween.cancel(tweenalpha2.uniqueId);

                tweenalpha1 = LeanTween.alphaCanvas(arrowActivator.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
                tweenalpha2 = LeanTween.alphaCanvas(talk.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
                canShowAgain = false;
            }

        }
    }
}
