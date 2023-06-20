using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(TrailRenderer))]
public class MakeItAObject : MonoBehaviour
{
    #region BasicComponents
    GameObject MyGOB;
    GameObject Player;
    HoldAndThrow holdAndThrow;
    public int QtdCaiu = 0;
    //public GameObject HitFx;
    public GameObject ExplodeFx;
    public int AttackDamage;

    private void Awake()
    {
        MyGOB = this.gameObject;
        Player = GameObject.Find("PlayerManager");
        holdAndThrow = Player.GetComponent<HoldAndThrow>();
    }
    private void Start()
    {
        MyGOB.tag = "Object";
        MyGOB.layer = 14;
        MyGOB.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
    }

    private void Update()
    {
        transform.rotation = new Quaternion(transform.transform.rotation.x, 0,
            transform.transform.rotation.z, 0);
        transform.localScale = new Vector3(0.05f, 0.05f, 1);
    }

    #endregion

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemies" && holdAndThrow.Estado != "Segurando")
        {
            collision.collider.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
        }
        else if(collision.collider.tag == "Enemies" && holdAndThrow.Estado == "Segurando")
        {
            Destruir();
        }
        else if (collision.collider.tag != "Player" && QtdCaiu > 0)
        {
            Destruir();
        }
        QtdCaiu = QtdCaiu + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies" && holdAndThrow.Estado != "Segurando")
        {
            collision.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
        }
        else if (collision.tag == "Enemies" && holdAndThrow.Estado == "Segurando")
        {
            Destruir();
        }
        else if(collision.tag != "Player" && QtdCaiu > 0)
        {
            Destruir();
        }
        QtdCaiu = QtdCaiu + 1;
    }
    #endregion

    #region M�todos
    void Destruir()
    {
        Instantiate(ExplodeFx, MyGOB.transform.position, Quaternion.identity);
        Destroy(MyGOB);
    }
    #endregion
}
