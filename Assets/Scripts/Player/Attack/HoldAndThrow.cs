using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ele ataca depois de jogar o objeto.

public class HoldAndThrow : MonoBehaviour
{
    #region Variáveis de Funcionamento
    GameObject grabDetect;
    GameObject boxHolder;
    public float rayDist = 2;
    LayerMask ObjectLayer;
    public string Estado = "Normal";

    public float force = 7000;
    public float attackRate = 2f;
    public float NextattackTime = 0f;

    Animator PlayerAni;

    #endregion

    #region Variáveis do objeto

    GameObject objectGO;
    GameObject FixedGO;
    PolygonCollider2D ObjectPoly;

    #endregion

    #region Start
    private void Start()
    {
        PlayerAni = GameObject.Find("Player").gameObject.GetComponent<Animator>();
        grabDetect = GameObject.Find("GrabDetect");
        boxHolder = GameObject.Find("GrabHolder");
        ObjectLayer = LayerMask.GetMask("ObjectLayer");
    }
    #endregion

    #region Update
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.transform.position, grabDetect.transform.right, rayDist, ObjectLayer);
        Debug.DrawRay(grabDetect.transform.position, grabDetect.transform.right * rayDist, Color.green);
        if (grabCheck.collider != null && grabCheck.collider.tag == "Object")
        {
            objectGO = grabCheck.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.J) || Input.GetButtonDown("AttackJoystick") && Estado != "Segurando")
            {
                Situação("Segurando");
;           }
        }
        if (Time.time >= NextattackTime && Time.time >= NextattackTime)
        {
            if (Estado == "Segurando" && Input.GetKeyDown(KeyCode.J) || Input.GetButtonDown("AttackJoystick"))
            {
                Jogar();
            }
        } 
    }
    #endregion

    #region Métodos
    void Situação(string estado)
    {
        switch (estado)
        {
            case "Segurando":
                {
                    Estado = "Segurando";
                    ActSituação("Segurar");
                }
                break;

            case "Normal":
                {
                    Estado = "Normal";
                }
                break;
        }
    }
   public void ActSituação(string estado)
   {
        switch (estado)
        {
            case "Segurar":
                {
                    FixedGO = objectGO;
                    objectGO.transform.SetParent(boxHolder.transform);
                    objectGO.transform.position = boxHolder.transform.position;
                    objectGO.GetComponent<Rigidbody2D>().isKinematic = true;
                    objectGO.GetComponent<PolygonCollider2D>().enabled = false;

                    PlayerAni.SetBool("Holding", true);
                    NextattackTime = Time.time + 1f / attackRate;
                }
                break;
        }
   }

    void Jogar()
    {
        Debug.Log("Entrou em jogar");
        FixedGO.GetComponent<PolygonCollider2D>().enabled = true;
        FixedGO.transform.parent = null;
        FixedGO.GetComponent<Rigidbody2D>().isKinematic = false;
        FixedGO.GetComponent<Rigidbody2D>().AddForce(boxHolder.transform.right * force);
        FixedGO.GetComponent<Rigidbody2D>().AddForce(boxHolder.transform.up * 1000);
        Invoke("EstadoNormal", 0 * Time.fixedDeltaTime);

        PlayerAni.SetBool("Holding", false);
    }
    void EstadoNormal()
    {
        Estado = "Normal";
    }
    #endregion
}
