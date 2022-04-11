using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject FireAttack;
    public GameObject shockWaveAttack;
    public GameObject summonAttack;
    public Transform summonAttackPos;
    public Transform fireGroundPos;
    public Transform shockwavePos;
    public float attackrate = 1f;
    float nextAttack = 0f;
    


    private void Update()
    {
        if(Time.time > nextAttack)
        {
            nextAttack = Time.time + attackrate;
            RandomState();
        }
        
        
    }

    public void summon()
    {
        Debug.Log("SUMMON ATTACK");
        Instantiate(summonAttack, summonAttackPos.transform.position, Quaternion.identity);
    }
    public void shockWave()
    {
        Debug.Log("SHOCK WAVE ATTACK");
        Instantiate(shockWaveAttack, shockwavePos.transform.position, Quaternion.identity);
    }
    public void fireGroundAttack()
    {
        Debug.Log("FIRE ATTACK");
        Instantiate(FireAttack, fireGroundPos.transform.position, Quaternion.identity);
    }
    public void RandomState()
    {
        int randomState = Random.Range(0, 3);
        if (randomState == 0)
        {
            summon();
        }
        else if (randomState == 1)
        {
            shockWave();
        }
        else if (randomState == 2)
        {
            fireGroundAttack();
        }
    }
}
