using System.Collections;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public GameObject panel, lines, icon, lifeBar, objective, npcName;

    public void dialogueOpen()
    {
        panel.GetComponent<CanvasGroup>().alpha = 0f;
        lines.GetComponent<CanvasGroup>().alpha = 0f;
        icon.GetComponent<CanvasGroup>().alpha = 0f;
        npcName.GetComponent<CanvasGroup>().alpha = 0f;
        lifeBar.GetComponent<CanvasGroup>().alpha = 1f;
        objective.GetComponent<CanvasGroup>().alpha = 1f;

        panel.GetComponent<RectTransform>().localScale = new Vector3(.7f, .7f, .7f);
        lines.GetComponent<RectTransform>().localScale = new Vector3(.3f, lines.GetComponent<RectTransform>().localScale.y, lines.GetComponent<RectTransform>().localScale.z);

        npcName.GetComponent<RectTransform>().localScale = new Vector3(.7f, .7f, .7f);

        LeanTween.alphaCanvas(panel.GetComponent<CanvasGroup>(), 0.9f, 1f).setEaseInQuad();
        LeanTween.alphaCanvas(lines.GetComponent<CanvasGroup>(), 1f, .7f).setEaseInQuad();
        LeanTween.alphaCanvas(npcName.GetComponent<CanvasGroup>(), 1f, 3f).setEaseInQuad().setDelay(.7f);



        LeanTween.alphaCanvas(lifeBar.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();
        LeanTween.alphaCanvas(objective.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();

        LeanTween.scale(panel, new Vector3(1f, 1f, 1f), .3f).setEaseOutCubic();
        LeanTween.scale(npcName, new Vector3(1f, 1f, 1f), 2f).setEaseOutCubic().setDelay(.7f);
        LeanTween.scale(lines, new Vector3(1f, lines.GetComponent<RectTransform>().localScale.y, lines.GetComponent<RectTransform>().localScale.z), .3f).setEaseOutCubic();

        StartCoroutine(removeNpcName());
    }

    public void dialogueClose()
    {
        LeanTween.alphaCanvas(panel.GetComponent<CanvasGroup>(), 0f, 1f).setEaseInQuad();        
        LeanTween.alphaCanvas(lines.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
        LeanTween.alphaCanvas(icon.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();
        LeanTween.alphaCanvas(npcName.GetComponent<CanvasGroup>(), 0f, 1f).setEaseInQuad();

        LeanTween.alphaCanvas(lifeBar.GetComponent<CanvasGroup>(), 1f, .2f).setEaseInQuad().setDelay(1f);
        LeanTween.alphaCanvas(objective.GetComponent<CanvasGroup>(), 1f, .2f).setEaseInQuad().setDelay(1f);
    }

    IEnumerator removeNpcName()
    {
        yield return new WaitForSeconds(5f);
        LeanTween.alphaCanvas(npcName.GetComponent<CanvasGroup>(), 0f, 2f).setEaseInQuad();
    }
}