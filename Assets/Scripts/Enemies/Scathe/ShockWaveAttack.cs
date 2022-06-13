using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveAttack : MonoBehaviour
{
    public Rigidbody2D rb;
    public float waveSpeed;
    public float selfDestoyTime;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(-waveSpeed, 0, 0);
        //rb.AddForce(Vector2.left * waveSpeed);
        Destroy(this.gameObject, selfDestoyTime);
    }
}
