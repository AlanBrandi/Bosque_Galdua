using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isplayeyinleftinside : MonoBehaviour
{
    public Animator BigTreeEntrance;
    public Animator alavanca;
    public GameObject luz_vermelha;
    public GameObject luz_verde;
    public bool Keycardtree = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            alavanca.SetBool("IsAlavancaAtivada", true);
            Keycardtree = true;
            Destroy(luz_vermelha);
            luz_verde.SetActive(true);
            BigTreeEntrance.SetTrigger("Open");
        }
    }
}