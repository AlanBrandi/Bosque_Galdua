using System.Collections;
using UnityEngine;

public class MaterialTransition : MonoBehaviour
{
    public Material defaultMaterial;
    public Material startMaterial;
    public Material endMaterial;
    public float transitionTime = 1.0f;

    Renderer _renderer;

    private Poison poison;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        StartCoroutine(TransitionMaterials());
        poison = FindObjectOfType<Poison>();
        poison = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<Poison>();
    }

    IEnumerator TransitionMaterials()
    {
        while (true)
        {
            if (poison != null && poison.isPoison)
            {
                // Alternar os materiais de partida e destino
                Material temp = startMaterial;
                startMaterial = endMaterial;
                endMaterial = temp;

                // Transição de material
                float startTime = Time.time;
                float elapsedTime = 0.0f;

                while (elapsedTime < transitionTime)
                {
                    float t = Mathf.Clamp01(elapsedTime / transitionTime);
                    _renderer.material.Lerp(startMaterial, endMaterial, t);
                    elapsedTime = Time.time - startTime;
                    yield return null;
                }

                _renderer.material = endMaterial;

                // Esperar um tempo antes de alternar novamente
                yield return null;
            }
            else
            {
                // Esperar um frame antes de verificar novamente

                float startTime = Time.time;
                float elapsedTime = 0.0f;

                while (elapsedTime < transitionTime)
                {
                    float t = Mathf.Clamp01(elapsedTime / transitionTime);
                    _renderer.material.Lerp(_renderer.material, defaultMaterial, t);
                    elapsedTime = Time.time - startTime;
                    yield return null;
                }
                _renderer.material = defaultMaterial;
                yield return null;

            }
        }


    }
}
