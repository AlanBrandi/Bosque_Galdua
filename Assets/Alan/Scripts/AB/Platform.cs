using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform startPos, pos1;
    public float speed;
    public Transform parent;
    public GameObject player;
    public Transform managert;
    public float waitTime = 1;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }
    private void FixedUpdate()
    {
        if (transform.position == startPos.position)
        {
            nextPos = pos1.position;
        }
        else if (transform.position == pos1.position)
        {
            nextPos = startPos.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.SetParent(parent);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.SetParent(managert);
        }
    }
}
