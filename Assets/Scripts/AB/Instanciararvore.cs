using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciararvore : MonoBehaviour
{
    public IsPlayerInside script;
    public GameObject prefab;
    public bool instanciou = false;

    private void Start()
    {
        prefab = prefab.gameObject;
    }
    private void Update()
    {
        if (script.playerinside == true)
        {
            Instantiate(prefab.gameObject, transform.position, Quaternion.identity);
           script.playerinside = false;
            instanciou = true;
        }
    }
}
