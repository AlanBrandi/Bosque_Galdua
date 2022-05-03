using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{
    public SpriteRenderer[] SR = new SpriteRenderer[1];
    List<float> originalAlpha = new List<float>();
    bool isT = true;
    //float[] originalAlpha;
    public bool isBackground = true;
    public float colorAlpha = .7f;
    void Start()
    {
        SR[0] = GetComponent<SpriteRenderer>();
        foreach (SpriteRenderer sr in SR)
        {
            originalAlpha.Add(sr.color.a);
        }
        /*foreach (float i in originalAlpha)
        {
            originalAlpha[i] = 
        }*/
    }


    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            StopAllCoroutines();
            StartCoroutine(IncreaseAlpha());
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(LowerAlpha());
        }
    }



    IEnumerator LowerAlpha()
    {


            foreach (SpriteRenderer sr in SR)
            {
                while (sr.color.a > colorAlpha)
                {
                    if (isBackground && sr.color.a > colorAlpha)
                    {
                        sr.color = new Color(1f, 1f, 1f, (sr.color.a - .01f));
                        Debug.Log("BackgroundL");
                    }
                    else if (sr.color.a > colorAlpha)
                    {
                        sr.color = new Color(0f, 0f, 0f, (sr.color.a - .01f));
                        Debug.Log("ForegroundL");
                    }

                    yield return new WaitForSeconds(.005f);


                }

            }
        
    }

    IEnumerator IncreaseAlpha()
    {

            foreach (SpriteRenderer sr in SR)
            {
                for (int i = 0; i < SR.Length; i++)
                {
                    
                    while (sr.color.a < originalAlpha[i])
                    {
                        if (isBackground && sr.color.a < originalAlpha[i])
                        {
                            Debug.Log("Entrou3");
                            sr.color = new Color(1f, 1f, 1f, (sr.color.a + .01f));
                            Debug.Log(originalAlpha[i]);
                        }
                        else if (sr.color.a < originalAlpha[i])
                        {
                            Debug.Log("Entrou3.5");
                            sr.color = new Color(0f, 0f, 0f, (sr.color.a + .01f));
                            Debug.Log(originalAlpha[i]);
                        }

                        yield return new WaitForSeconds(.005f);
                       
                    }

                }

                Debug.Log("EVazou");
            }
        
    }
}