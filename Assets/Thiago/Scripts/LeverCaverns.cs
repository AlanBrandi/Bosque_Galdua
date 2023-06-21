using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCaverns : MonoBehaviour
{
    private Animator lever;
    public GameObject monstrinho;
    private LeversMessage message;

    public Animator elevatorAnim;

    public GameObject door;

    public GameObject mole;
    
    public bool isElevator;

    private AudioSource _audioSource;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    private void Start()
    {
        lever = GetComponent<Animator>();
        message = GetComponent<LeversMessage>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                if (UserInput.instance.playerController.InGame.Interact.triggered)
                {
                    if(monstrinho != null)
                    {
                        EventManager.Instance.ActivateMonstrinhoTrap(monstrinho);
                    }

                    if (door != null)
                    {
                        Destroy(door.gameObject);
                        _audioSource.Play();
                    }

                    if (mole != null)
                    {
                        Destroy(mole.gameObject);
                    }

                    if (elevatorAnim != null)
                    {
                        elevatorAnim.SetTrigger("UP");
                        StartCoroutine(down());
                    }

                    if (door1 != null)
                    {
                        Animator anim = door1.GetComponent<Animator>();
                        StartCoroutine(leverUpAgain());
                        anim.SetTrigger("Action");
                    }
                    if (door2 != null)
                    {
                        Animator anim = door2.GetComponent<Animator>();
                        StartCoroutine(leverUpAgain());
                        anim.SetTrigger("Action");
                    }
                    if (door3 != null)
                    {
                        Animator anim = door3.GetComponent<Animator>();
                        StartCoroutine(leverUpAgain());
                        anim.SetTrigger("Action");
                    }
                    if (door4 != null)
                    {
                        Animator anim = door4.GetComponent<Animator>();
                        StartCoroutine(leverUpAgain());
                        anim.SetTrigger("Action");
                    }
                    
                    lever.SetBool("IsLeverOn", true);
                }
            }
            
    }

    IEnumerator leverUpAgain()
    {
        yield return new WaitForSeconds(.5f);
        lever.SetBool("IsLeverOn", false);
    }

    IEnumerator down()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(canShowMessageAgain());
        lever.SetBool("IsLeverOn", false);
        elevatorAnim.SetTrigger("DOWN");
    }

    IEnumerator canShowMessageAgain()
    {
        yield return new WaitForSeconds(2f);
        message.canShowAgain = true;
    }
}
