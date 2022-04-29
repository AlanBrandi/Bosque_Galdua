using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveAttack : MonoBehaviour
{
    Rigidbody rb;
    public float waveSpeed;
    public float selfDestoyTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(-waveSpeed, 0, 0);
        Destroy(this.gameObject, selfDestoyTime);
    }
}
