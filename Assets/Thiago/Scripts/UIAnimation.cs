using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public GameObject panel, lines, icon;

    public void dialogueOpen()
    {
        panel.GetComponent<CanvasGroup>().alpha = 0f;
        lines.GetComponent<CanvasGroup>().alpha = 0f;
        icon.GetComponent<CanvasGroup>().alpha = 0f;

        panel.GetComponent<RectTransform>().localScale = new Vector3(.7f, .7f, .7f);
        lines.GetComponent<RectTransform>().localScale = new Vector3(.3f, lines.GetComponent<RectTransform>().localScale.y, lines.GetComponent<RectTransform>().localScale.z);

        LeanTween.alphaCanvas(panel.GetComponent<CanvasGroup>(), 0.9f, 1f).setEaseInQuad();
        LeanTween.alphaCanvas(lines.GetComponent<CanvasGroup>(), 1f, .7f).setEaseInQuad();

        LeanTween.scale(panel, new Vector3(1f, 1f, 1f), .3f).setEaseOutCubic();
        LeanTween.scale(lines, new Vector3(1f, lines.GetComponent<RectTransform>().localScale.y, lines.GetComponent<RectTransform>().localScale.z), .3f).setEaseOutCubic();
    }

    public void dialogueClose()
    {
        LeanTween.alphaCanvas(panel.GetComponent<CanvasGroup>(), 0f, 1f).setEaseInQuad();
        LeanTween.alphaCanvas(lines.GetComponent<CanvasGroup>(), 0f, .7f).setEaseInQuad();
        LeanTween.alphaCanvas(icon.GetComponent<CanvasGroup>(), 0f, .2f).setEaseInQuad();
    }
}