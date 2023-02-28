using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlueInside : MonoBehaviour
{
    public bool blueinside = false;
    public Rigidbody2D ridg;
    public Collider2D col;
    public GameObject obj;
    public GameObject sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box [blue]"))
        {
            blueinside = true;
            sound.SetActive(true);
            print("Blue entrou");
            collision.transform.localPosition = new Vector2(-2.48f, 0.346f);
            collision.transform.localRotation = new Quaternion(0, 0, 0, 0);
            obj.layer = LayerMask.NameToLayer("Water");
            ridg.bodyType = RigidbodyType2D.Static;
            col.isTrigger = true;
            
        }
    }
}
