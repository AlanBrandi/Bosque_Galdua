using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSetupFight : MonoBehaviour
{
    public GameObject oneSidePlatform;

    public GameObject blackGround;

    public GameObject mole;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blackGround.SetActive(true);
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
    
    
}
