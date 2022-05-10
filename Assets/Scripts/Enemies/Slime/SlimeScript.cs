using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    //Rigidbody2D rb;
    public int dano = 5;
    public float speed = 5;
    SpriteRenderer enemySprite;
    //public BoxCollider2D Boxcollider;
    //public CircleCollider2D Circlecollider;
    public Transform startPos, pos1;
    MyHealthSystem healthSystem;
    AudioSource slimeSounds;
    Vector3 nextPos;

    private void Awake()
    {
        healthSystem = GameObject.FindObjectOfType<MyHealthSystem>();
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
            healthSystem.Dano(dano);
        }
    }
   /* public void MudarColi()
    {
        Circlecollider.enabled = true;
    }
    public void VoltarColi()
    {
        Circlecollider.enabled = false;
    }*/
}
