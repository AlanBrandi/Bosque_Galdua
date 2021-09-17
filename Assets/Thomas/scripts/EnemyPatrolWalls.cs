using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolWalls : MonoBehaviour
{
    //declarações
    public float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
      

    }

    void Update()
    {
        if (isFacingRight())
        {
            //anda pra direita
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            //anda pra esquerda
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    //quando cai pra fora de uma plataforma:
    private void OnTriggerExit2D(Collider2D collision)
    {
        //gira o personagem ao sair de uma plataforma, nao funciona com personagem bones/de muitos pedaços!
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
