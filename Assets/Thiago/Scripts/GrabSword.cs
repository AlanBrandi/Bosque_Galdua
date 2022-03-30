using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSword : MonoBehaviour
{
    public GameObject playerManager;
    public GameObject sword;
    void Start()
    {
        playerManager.GetComponent<PlayerAttack>().enabled = false;
        playerManager.GetComponent<PlayerHighAttack>().enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colisão");
            playerManager.GetComponent<PlayerAttack>().enabled = true;
            playerManager.GetComponent<PlayerHighAttack>().enabled = true;
            Destroy(this.gameObject);
            sword.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    
}
