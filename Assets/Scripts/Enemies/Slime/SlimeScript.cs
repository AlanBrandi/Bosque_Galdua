using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public int dano = 5;
    public float speed = 5;
    SpriteRenderer enemySprite;
    public Transform startPos, pos1;
    PlayerHealth healthSystem;
    AudioSource slimeSounds;
    Vector3 nextPos;

    private void Awake()
    {
        healthSystem = GameObject.FindObjectOfType<PlayerHealth>();
        enemySprite = GetComponent<SpriteRenderer>();
        nextPos = startPos.position;
        slimeSounds = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (transform.position == startPos.position)
        {
            nextPos = pos1.position;
            enemySprite.flipX = false;
        }
        if (transform.position == pos1.position)
        {
            nextPos = startPos.position;
            enemySprite.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    public void slimeSound()
    {
        float randomPitch = Random.Range(0.8f, 1.2f);
        slimeSounds.pitch = randomPitch;
        slimeSounds.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Slime deu dano em player.");
            healthSystem.Hit(dano);
        }
    }
}
