using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObjectInside : MonoBehaviour
{
    public Door door;
    IsObjectInside isObjectInside;
    private void Start()
    {
        isObjectInside = GetComponent<IsObjectInside>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            Debug.Log("Objeto colidiu com botão");
            door.Open();
            Destroy(isObjectInside);
        }
    }
}
