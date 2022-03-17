using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class MakeItAObject : MonoBehaviour
{
    #region BasicComponents
    GameObject MyGOB;
    GameObject Player;


    private void Awake()
    {
        MyGOB = this.gameObject;
        Player = GameObject.Find("PlayerManager");
    }
    private void Start()
    {
        MyGOB.tag = "Object";
        MyGOB.layer = 14;
        MyGOB.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
    }
    #endregion

    public GameObject HitFx;
    public GameObject ExplodeFx;
    public int AttackDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemies")
        {
            collision.collider.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
        }

        if (collision.collider.tag != "Player" && Player.GetComponent<ObjectScript>().pegou == false && Player.GetComponent<ObjectScript>().pegouNum > 0)
        {
            Destruir();
            //dar dano no bixo
        }
    }

    void Destruir()
    {
       // Instantiate(HitFx, positionHit, Quaternion.identity);
        Instantiate(ExplodeFx, MyGOB.transform.position, Quaternion.identity);
        Destroy(MyGOB);
    }
}
