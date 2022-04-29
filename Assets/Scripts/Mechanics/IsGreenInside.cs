using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGreenInside : MonoBehaviour
{
    public bool greeninside = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box [green]"))
        {
            greeninside = true;
            print("green entrou");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Box [green]"))
        {
            greeninside = false;
            print("green saiu");
        }
    }
}
