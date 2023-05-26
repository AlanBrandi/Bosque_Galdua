using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToSelfDestroy;
    public GameObject fxDie;
    private void Start()
    {
        Destroy(gameObject, timeToSelfDestroy);
    }
    private void OnDestroy()
    {
        Instantiate(fxDie, transform.position, Quaternion.identity);
    }
}
