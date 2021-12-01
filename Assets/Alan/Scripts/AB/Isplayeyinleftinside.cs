using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Isplayeyinleftinside : MonoBehaviour
{
    public Animator BigTreeEntrance;
    Animator lever;
    public GameObject luz_vermelha;
    public GameObject luz_verde;
    public bool Keycardtree = false;
    bool PlayerInside = false;

    public TMP_Text TopText;
    public TMP_Text DownText;

    private void Start()
    {
        lever = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lever.SetBool("IsLeverOn", true);
            Keycardtree = true;
            Destroy(luz_vermelha);
            StartCoroutine(ChangeLight());
            PlayerInside = true;
            IEnumerator ChangeLight()
            {
                yield return new WaitForSecondsRealtime(.3f);
                luz_verde.SetActive(true);
                BigTreeEntrance.SetTrigger("Open");
            }
        }
    }

    private void Update()
    {
        if(PlayerInside == true)
        {
            TopText.text = "Siga sua aventura";
            DownText.text = "Ache a entrada";
        }
    }
}