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
        else if (collision.collider.tag == "Ground")
        {
            Destruir();
        }
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
        else if (collision.tag == "Ground")
        {
            Destruir();
        }
    }
    #endregion

    #region Métodos
    void Destruir()
    {
        Instantiate(ExplodeFx, MyGOB.transform.position, Quaternion.identity);
        Destroy(MyGOB);
    }
    #endregion
}
