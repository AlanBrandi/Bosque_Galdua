using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Isplayeyinleftinside : MonoBehaviour
{
    GameObject BTG;
    Animator BTGAnim;
    AudioSource BTGAudio;
    Animator lever;
    bool actionExec = false;
    public bool Keycardtree = false;
    public TMP_Text TopText;
    public TMP_Text DownText;

    private void Start()
    {
        BTG = GameObject.Find("BigTreeGate");
        BTGAnim = BTG.GetComponent<Animator>();
        BTGAudio = BTG.GetComponent<AudioSource>();
        lever = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (actionExec == false)
        {
            if (collision.CompareTag("Player"))
            {
                lever.SetBool("IsLeverOnSpecial", true);
                Keycardtree = true;
                TopText.text = "Siga sua aventura";
                DownText.text = "Ache a entrada";
                BTGAnim.SetTrigger("Open");
                BTGAudio.Play();
                actionExec = true;
            }
        }
    }
}