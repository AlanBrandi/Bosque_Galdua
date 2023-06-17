using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCavern : MonoBehaviour
{
    public GameObject door;
    private AudioSource audio;
    public GameObject monstrinho1;
    public GameObject monstrinho2;
    public GameObject mole;
    

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(monstrinho1 != null)
            {
                EventManager.Instance.ActivateMonstrinhoTrap(monstrinho1);
            }
            if(monstrinho2 != null)
            {
                EventManager.Instance.ActivateMonstrinhoTrap(monstrinho2);
            }
            audio.Play();
            Destroy(mole);
            Destroy(door.gameObject);
            Destroy(GetComponent<ButtonCavern>());
        }
    }
}
