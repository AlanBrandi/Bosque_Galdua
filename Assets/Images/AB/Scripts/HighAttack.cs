using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighAttack : MonoBehaviour
{
    public SpriteRenderer MySR;
    void Start()
    {
        MySR = GetComponent<SpriteRenderer>();
        MySR.enabled = false;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.J))
        {
            MySR.enabled = true;
        }
    }
}
