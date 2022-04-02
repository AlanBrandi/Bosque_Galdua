using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBoxInside : MonoBehaviour
{
    public Door door;
    IsBoxInside isBoxInside;
    private void Start()
    {
        isBoxInside = GetComponent<IsBoxInside>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("Box colidiu com botão");
            door.Open();
            Destroy(isBoxInside);
        }
    }
}