using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IsPlayerInside : MonoBehaviour
{
    Transform MyTransform;
    Animator lever;
    public Transform spawnLocation;
    public GameObject spawnGO;
    bool actionExec = false;

    public TMP_Text TopText;
    public TMP_Text DownText;

    private Collider2D colliderComponent;

    public GameObject monstrinho;


    private void Start()
    {
        lever = GetComponent<Animator>();
        MyTransform = GetComponent<Transform>();
        colliderComponent = GetComponent<Collider2D>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (actionExec == false)
        {
            if (collision.CompareTag("Player") && UserInput.instance.playerController.InGame.Debug_E.triggered)
            {
                if(monstrinho != null)
                {
                    EventManager.Instance.ActivateMonstrinhoTrap(monstrinho);
                }
                
                print("player entrou");
                Instantiate(spawnGO, spawnLocation.position, Quaternion.identity);
                lever.SetBool("IsLeverOn", true);
                TopText.text = "Procure a outra Alavanca";
                DownText.text = "Use o tronco para subir";
                actionExec = true;
                Destroy(colliderComponent);
            }
        }
       
    }
}