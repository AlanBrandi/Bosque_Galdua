using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource dummySound;
    EnemiesScript enemiesScript;

    private void Awake()
    {
        dummySound = GetComponent<AudioSource>();
        enemiesScript = GetComponent<EnemiesScript>();
    }

    private void Update()
    {
        if (enemiesScript.currentHealth <= 5)
        {
            enemiesScript.currentHealth = 1000;
        }
    }
}
