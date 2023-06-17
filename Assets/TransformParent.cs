using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformParent : MonoBehaviour
{
    Transform playerManager;
    GameObject player;
    public string child = "Player";
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(child))
        {
            player.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.SetParent(playerManager);
        }
    }
}
