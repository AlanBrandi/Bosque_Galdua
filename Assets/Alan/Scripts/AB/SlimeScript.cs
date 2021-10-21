using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    Rigidbody2D rb;
    public int dano = 5;
    public float speed = 5;
    GameObject Player;
    BoxCollider2D Boxcollider;
    CircleCollider2D Circlecollider;
    SpriteRenderer SR_slime;

    private void Start()
    {
        Boxcollider = this.GetComponent<BoxCollider2D>();
        Circlecollider = this.GetComponent<CircleCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        SR_slime = this.GetComponent<SpriteRenderer>();
        Invoke("Esquerda", 0);
    }

    //Moving
    void Esquerda()
    {
        SR_slime.flipX = true;
        Vector2 direction = new Vector2(1, 0);
        rb.velocity = direction * speed;
        Invoke("Direita", 5);
    }
    void Direita()
    {
        SR_slime.flipX = false;
        Vector2 direction = new Vector2(-1, 0);
        rb.velocity = direction * speed;
        Invoke("Esquerda", 5);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player.GetComponent<MyHealthSystem>().Dano(dano);
        }
    }
    /*public void MudarColi()
    {
        Boxcollider.enabled = false;
        Circlecollider.enabled = true;
    }
    public void VoltarColi()
    {
        Circlecollider.enabled = false;
        Boxcollider.enabled = true;
    }*/
}
