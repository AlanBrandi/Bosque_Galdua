using UnityEngine;
using UnityEngine.UI;

public class BlurEffect : MonoBehaviour
{
    public Image image;
    public float blurAmount = 5f;

    private Material blurMaterial;

    private void Start()
    {
        blurMaterial = image.material;
    }

    private void Update()
    {
        blurMaterial.SetFloat("_Size", blurAmount);
    }
}