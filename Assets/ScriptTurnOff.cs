using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTurnOff : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<PlayerHighAttack>().enabled = false;
        }
    }
}
