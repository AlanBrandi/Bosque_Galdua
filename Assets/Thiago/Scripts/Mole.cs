using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public GameObject projectile;
    public Transform ProjectilePos;
    public float attackrate;
    int randomState = 0;
    float nextAttack = 0f;


    private void Update()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackrate;
            RandomState();
        }       
    }

    public void Projectile()
    {
        Debug.Log("THROW PROJECTILE");
        Instantiate(projectile, ProjectilePos.transform.position, Quaternion.identity);
    }
    public void Dive()
    {
        Debug.Log("DIVE");       
    }
    
   
    public void RandomState()
    {
        randomState = Random.Range(0, 1);
        if (randomState == 0)
        {
            Projectile();
        }
        else if (randomState == 1)
        {
            Dive();
        }
    }
}
