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
                if (UserInput.instance.playerController.InGame.Debug_E.triggered)
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
                    
                    lever.SetBool("IsLeverOn", true);
                }
            }
            
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
