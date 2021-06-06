using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInside : MonoBehaviour
{
    Animator MyAnimator;
    Transform MyTransform;
    public Animator alavanca;
    public Instanciararvore scriptarvore;
    public bool playerinside = false; 
    

    private void Start()
    {
        MyAnimator = GetComponentInParent<Animator>();
        MyTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (scriptarvore.instanciou == true)
        {
            MyTransform.position = new Vector3(0, 700, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("player entrou");
            alavanca.SetBool("IsLeverOn", true);
            MyAnimator.SetBool("PlayerInside", true);
            playerinside = true;
        }
    }
}