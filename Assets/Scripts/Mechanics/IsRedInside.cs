using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRedInside : MonoBehaviour
{
    public bool redinside = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box [red]"))
        {
            redinside = true;
            print("red entrou");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Box [red]"))
        {
            redinside = false;
            print("red saiu");
        }
    }
}
