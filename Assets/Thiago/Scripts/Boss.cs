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
    public float attackrate;
    public float attackrate2;
    int randomState = 0;
    public acidSpawn acid;
    float nextAttack = 0f;
    

    private void Start()
    {
        acid = acid.GetComponent<acidSpawn>();
    }

    private void Update()
    {
        if(Time.time > nextAttack)
        {           
                nextAttack = Time.time + attackrate;
                RandomState();
            if(randomState == 3)
            {
                acid.acidWave();
            }
                      
        }        
    }

    public void summon()
    {
        Debug.Log("SUMMON ATTACK");
       // Instantiate(summonAttack, summonAttackPos.transform.position, Quaternion.identity);
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

    public void acidRain()
    {
        Debug.Log("ACID RAIN");
       
        acid.acidWave();
        
       
    }
    public void lazer()
    {
        Debug.Log("LAZER ATTACK");
    }
    public void RandomState()
    {
        randomState = Random.Range(0, 4);
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
