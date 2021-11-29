using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isplayeyinleftinside : MonoBehaviour
{
    public Animator BigTreeEntrance;
    Animator lever;
    public GameObject luz_vermelha;
    public GameObject luz_verde;
    public bool Keycardtree = false;

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
            IEnumerator ChangeLight()
            {
                yield return new WaitForSecondsRealtime(.3f);
                luz_verde.SetActive(true);
                BigTreeEntrance.SetTrigger("Open");
            }
        }
    }
}