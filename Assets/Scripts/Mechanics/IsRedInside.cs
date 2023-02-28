using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRedInside : MonoBehaviour
{
    public bool redinside = false;
    public Rigidbody2D ridg;
    public Collider2D col;
    public GameObject obj;
    public GameObject sound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box [red]"))
        {
            redinside = true;
            print("red entrou");
            sound.SetActive(true);
            collision.transform.localPosition = new Vector2(-5.32f, 0.59f);
            collision.transform.localRotation = new Quaternion(0, 0, 0, 0);
            obj.layer = LayerMask.NameToLayer("Water");
            ridg.bodyType = RigidbodyType2D.Static;
            col.isTrigger = true;
        }
    }
}
