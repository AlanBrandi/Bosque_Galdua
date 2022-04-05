using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(TrailRenderer))]
public class MakeItAHardObject : MonoBehaviour
{
    #region BasicComponents
    GameObject MyGOB;
    GameObject Player;
    ObjectScript objectScript;
    public GameObject ExplodeFx;
    public int AttackDamage;


    private void Awake()
    {
        MyGOB = this.gameObject;
        Player = GameObject.Find("PlayerManager");
        objectScript = Player.GetComponent<ObjectScript>();
    }
    private void Start()
    {
        MyGOB.tag = "Object";
        MyGOB.layer = 14;
        MyGOB.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
    }
    #endregion

    #region Update
    private void Update()
    {
       
    }
    #endregion

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemies" && objectScript.pegou == false)
        {
            collision.collider.GetComponent<EnemiesScript>().TakeDamage(AttackDamage);
        }
    }
    #endregion
}
