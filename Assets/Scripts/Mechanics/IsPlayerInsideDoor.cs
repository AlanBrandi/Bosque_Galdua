using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInsideDoor : MonoBehaviour
{
    public BoxCollider2D doorCollider;
    IsPlayerInsideDoor iPID;
    private void Start()
    {
        iPID = GetComponent<IsPlayerInsideDoor>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorCollider.gameObject.SetActive(true);
            Destroy(iPID);
        }
    }
}
