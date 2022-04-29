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

    private void Start()
    {
        lever = GetComponent<Animator>();
        MyTransform = GetComponent<Transform>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (actionExec == false)
        {
            if (collision.CompareTag("Player"))
            {
                print("player entrou");
                Instantiate(spawnGO, spawnLocation.position, Quaternion.identity);
                lever.SetBool("IsLeverOn", true);
                TopText.text = "Procure a outra Alanvanca";
                DownText.text = "Use o tronco para subir";
                actionExec = true;
            }
        }
    }
}