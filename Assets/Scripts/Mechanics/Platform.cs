using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //public Transform startPos, pos1;
    public float speed;
    //Transform parent;
    Transform[] transforms;
    GameObject player;
    Transform managert;
    public float waitTime = 1;

    Vector3 nextPos;

    void Start()
    {
        transforms = GetComponentsInChildren<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        managert = GameObject.FindGameObjectWithTag("PlayerManager").transform;
        nextPos = transforms[2].position;
    }
    private void FixedUpdate()
    {
        if (transforms[1].transform.position == transforms[2].position)
        {
            nextPos = transforms[3].position;
        }
        else if (transforms[1].transform.position == transforms[3].position)
        {
            nextPos = transforms[2].position;
        }
        transforms[1].transform.position = Vector3.MoveTowards(transforms[1].transform.position, nextPos, speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Oi");
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.SetParent(transforms[0]);
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
