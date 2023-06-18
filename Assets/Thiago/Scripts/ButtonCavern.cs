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
    public PlayerMovement player;

    public GameObject elevatorPressed;
    public GameObject totem;
    

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.isFLoating)
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
            if (mole != null)
            {
                Destroy(mole);
            }

            if (door != null)
            {
                Destroy(door.gameObject);
            }

            if (elevatorPressed != null)
            {
                elevatorPressed.SetActive(true);
            }

            if (totem != null)
            {
                totem.SetActive(true);
            }
            
            Destroy(GetComponent<ButtonCavern>());
        }
    }
}
