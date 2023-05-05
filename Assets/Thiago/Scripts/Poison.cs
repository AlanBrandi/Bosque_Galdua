using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public bool isPoison;
    private PlayerHealth health;
    public float delayHit;
    private float delayTimer = 0;
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        delayTimer = delayHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPoison)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                health.Hit(0);
                delayTimer = delayHit;
            }
            
        }
        else
        {
            delayTimer = delayHit;
        }
    }
}
