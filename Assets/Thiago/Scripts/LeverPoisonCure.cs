using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPoisonCure : MonoBehaviour
{
    private Animator animLever;
    public Animator animPlat;
    public float MyTimer;
    public float timer;
    private bool isActivate;
    private void Start()
    {
        animLever = GetComponent<Animator>();
        timer = 0;
    }
    private void Update()
    {
        if (isActivate)
        {
            timer += Time.deltaTime;
            if (timer >= MyTimer)
            {
                animPlat.SetTrigger("Up");
                animLever.SetTrigger("Deactivate");
                timer = MyTimer;
                isActivate = false;
            }
        }
        else
        {
            isActivate = false;
            timer = 0;
        }
    }

    public void ActivateEvent()
    {
        if (!isActivate)
        {
            isActivate = true;
            animPlat.SetTrigger("Down");
            animLever.SetTrigger("Activate");
        }
        
    }
}
