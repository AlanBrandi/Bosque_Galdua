using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HoldAndThrow : MonoBehaviour
{
    #region Vari�veis de Funcionamento
    GameObject grabDetect;
    GameObject boxHolder;
    public float rayDist = 2;
    LayerMask ObjectLayer;
    public string Estado = "Normal";

    public float force = 5;
    public float attackRate = 2f;
    public float NextattackTime = 0f;
    #endregion

    #region Vari�veis do objeto

    GameObject objectGO;
    PolygonCollider2D ObjectPoly;

    #endregion

    #region Start
    private void Start()
    {
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
            ObjectPoly = grabCheck.collider.gameObject.GetComponent<PolygonCollider2D>();

            if (Input.GetKeyDown(KeyCode.J) && Estado != "Segurando")
            {
               Situa��o("Segurando");
            }

        }
       /* if (Estado == "Segurando")
        {
            Situa��o("Segurando");
        }
       */
    }
    #endregion

    #region M�todos
    void Situa��o(string estado)
    {
        switch (estado)
        {
            case "Segurando":
                {
                    Estado = "Segurando";
                    ActSitua��o("Segurar");
                }
                break;

            case "Normal":
                {
                    Estado = "Normal";
                }
                break;
        }
    }
   public void ActSitua��o(string estado)
   {
        switch (estado)
        {
            case "Segurar":
                {

                    objectGO.GetComponent<Transform>().SetParent(boxHolder.transform.parent);
                    objectGO.GetComponent<Transform>().position = boxHolder.transform.position;
                    objectGO.GetComponent<Rigidbody2D>().isKinematic = true;
                    ObjectPoly.enabled = false;
                    //anima��o
                    //PlayerAni.SetBool("Holding", true);
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        ActSitua��o("Jogar");
                    }
                }
                break;

            case "Jogar":
                {

                    ObjectPoly.enabled = true;
                    objectGO.transform.parent = null;
                    objectGO.GetComponent<Rigidbody2D>().isKinematic = false;
                    objectGO.GetComponent<Rigidbody2D>().AddForce(boxHolder.transform.right * force);
                    objectGO.GetComponent<Rigidbody2D>().AddForce(boxHolder.transform.up * 10);
                    //anima��o
                    //PlayerAni.SetBool("Holding", false);

                   // NextattackTime = Time.time + 1f / attackRate;
                }
                break;
        }
   }
    #endregion
}
