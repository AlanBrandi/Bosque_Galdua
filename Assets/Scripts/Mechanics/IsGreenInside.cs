using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGreenInside : MonoBehaviour
{
    public bool greeninside = false;
    public Rigidbody2D ridg;
    public Collider2D col;
    public GameObject obj;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box [green]"))
        {
            greeninside = true;
            print("green entrou");

            collision.transform.localPosition = new Vector2(0.018f, 0.091f);
            collision.transform.localRotation = new Quaternion(0, 0, 0, 0);
            obj.layer = LayerMask.NameToLayer("Water");
            ridg.bodyType = RigidbodyType2D.Static;
            col.isTrigger = true;

        }
    }
}
