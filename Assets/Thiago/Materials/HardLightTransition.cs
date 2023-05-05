using System.Collections;
using UnityEngine;

public class HardLightTransition : MonoBehaviour
{

    public Color defaultColor;
    public Color startColor;
    public Color endColor;
    public float transitionTime = 1.0f;
    private HardLight2D _light;
    private Poison poison;

    void Start()
    {
        _light = GetComponent<HardLight2D>();
        StartCoroutine(TransitionColors());
        poison = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<Poison>();
    }

    IEnumerator TransitionColors()
    {
        while (true)
        {
            if (poison != null && poison.isPoison)
            {
                // Alternar as cores de partida e destino
                Color temp = startColor;
                startColor = endColor;
                endColor = temp;

                // Transição de cor
                float startTime = Time.time;
                float elapsedTime = 0.0f;

                while (elapsedTime < transitionTime)
                {
                    float t = Mathf.Clamp01(elapsedTime / transitionTime);
                    _light.Color = Color.Lerp(startColor, endColor, t);
                    elapsedTime = Time.time - startTime;
                    yield return null;
                }

                _light.Color = endColor;

                // Esperar um tempo antes de alternar novamente
                yield return null;
            }
            else
            {
                float startTime = Time.time;
                float elapsedTime = 0.0f;

                while (elapsedTime < transitionTime)
                {
                    float t = Mathf.Clamp01(elapsedTime / transitionTime);
                    _light.Color = Color.Lerp(_light.Color, defaultColor, t);
                    elapsedTime = Time.time - startTime;
                    yield return null;
                }
                _light.Color = defaultColor;

                yield return null;
            }
        }
    }
}

