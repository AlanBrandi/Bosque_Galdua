using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePoison : MonoBehaviour
{
    private Poison poison;
    private PlayerHealth live;
    [SerializeField] private Mole mole;
    private bool isTrying = false;
    private bool canAddLives = true;
    void Start()
    {
        poison = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<Poison>();
        live = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Debug_E.triggered)
        {
            isTrying = true;
            StartCoroutine(backToFalse());
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
            mole.playerIsInPlat = true;
        }
        if (this.gameObject.tag == "PoisonCure")
        {
            if (isTrying && collision.CompareTag("Player"))
            {
                poison.isPoison = false;
            }
        }
        else
        {
            if (isTrying && canAddLives && collision.CompareTag("Player"))
            {
                live.AddLives(2);
                canAddLives = false;
                StartCoroutine(addLivesDelay());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mole.playerIsInPlat = false;
        }
    }
    IEnumerator backToFalse()
    {
        yield return new WaitForSeconds(0.5f);
        isTrying = false;
    }
    IEnumerator addLivesDelay()
    {
        yield return new WaitForSeconds(8f);
        canAddLives = true;
    }
}
