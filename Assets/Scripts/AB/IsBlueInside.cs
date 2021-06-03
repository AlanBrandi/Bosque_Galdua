using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlueInside : MonoBehaviour
{
    public bool blueinside = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box [blue]"))
        {
            blueinside = true;
            print("Blue entrou");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Box [blue]"))
        {
            blueinside = false;
            print("Blue saiu");
        }
    }
}
