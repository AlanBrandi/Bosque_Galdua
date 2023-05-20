using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public GameObject panel, lines, icon;

    public void dialogueOpen()
    {
        panel.GetComponent<CanvasGroup>().alpha = 0f;
        lines.GetComponent<CanvasGroup>().alpha = 0f;
        icon.GetComponent<CanvasGroup>().alpha = 0f;

        // Aplica as alterações de alpha usando o LeanTween
        LeanTween.alphaCanvas(panel.GetComponent<CanvasGroup>(), 0.7f, 1f).setEaseInQuad();
        LeanTween.alphaCanvas(lines.GetComponent<CanvasGroup>(), 1f, .7f).setEaseInQuad();
        LeanTween.alphaCanvas(icon.GetComponent<CanvasGroup>(), 0.7f, .5f).setEaseInQuad().setDelay(.5f);
    }
}