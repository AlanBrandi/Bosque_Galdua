using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoleSetupFight : MonoBehaviour
{
    public GameObject oneSidePlatform;

    public GameObject blackGround;

    public GameObject blackGround2;

    public GameObject mole;

    bool  musicStart = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blackGround.SetActive(true);
            blackGround2.SetActive(true);
            if (!musicStart)
            {
                audioSource.Stop();
                audioSource2.Play();
                musicStart = true;
            }
            oneSidePlatform.SetActive(false);
            StartCoroutine(spawnMole());

        }
    }
    
    IEnumerator spawnMole()
    {
        yield return new WaitForSeconds(2.5f);
        mole.SetActive(true);
        Collider2D col = mole.GetComponent<Collider2D>();
        yield return new WaitForSeconds(.5f);
        col.isTrigger = false;
        yield return new WaitForSeconds(2f);
        Mole molee = mole.GetComponent<Mole>();
        molee.enabled = true;
    }

    private void Update()
    {
        Mole molee = mole.GetComponent<Mole>();
        if (molee.enabled)
        {
            if (mole.GetComponent<EnemiesScript>().currentHealth <= 0)
            {
                audioSource2.Stop();
                audioSource.Play();
            } 
        }
    }
}
