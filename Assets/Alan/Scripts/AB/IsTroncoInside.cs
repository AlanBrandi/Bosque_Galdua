using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IsTroncoInside : MonoBehaviour
{
    public GameObject LadoErrado;
    bool troncoInside = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tronco"))
        {
            Debug.Log("Tronco entrou");
            troncoInside = true;
        }
    }
   
    private void Update()
    {
        if(troncoInside == true)
        {
            LadoErrado.SetActive(true);
            Invoke("Saiu", 3);
        }
    }

    void Saiu()
    {
        troncoInside = false;
        LadoErrado.SetActive(false);
    }
}
