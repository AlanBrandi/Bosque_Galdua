using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public GameObject Player;
    public Transform Player_Tranform;
    void Start()
    {
        Player = GetComponent<GameObject>();
        Player_Tranform = GetComponent<Transform>();
    }
}
