using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int dano = 5;
    public float speed = 5;
    public SpriteRenderer SR_slime;
    public BoxCollider2D Boxcollider;
    public CircleCollider2D Circlecollider;

    GameObject Player;

    private void Start()
    {
        Invoke("Esquerda", 0);
    }

    //Moving
    /*void Esquerda()
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
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player.GetComponent<MyHealthSystem>().Dano(dano);
        }
    }
    public void MudarColi()
    {
        Circlecollider.enabled = true;
    }
    public void VoltarColi()
    {
        Circlecollider.enabled = false;
    }
}
