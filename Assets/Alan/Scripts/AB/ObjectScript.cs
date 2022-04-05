using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectScript : MonoBehaviour
{
    #region Basics_variable

    public float rayDist = 2;
    public float force = 5;
    public bool pegou = false;
    public bool HitObjeto = false;
    LayerMask ObjectLayer;

    public float attackRate = 2f;
    public float NextattackTime = 0f;

    PolygonCollider2D ObjectPoly;
    GameObject boxHolder;
    GameObject grabDetect;
    Rigidbody2D objectRB;
    GameObject objectGO;

    public Animator PlayerAni;
    public int pegouNum = 0;
    private void Awake()
    {
        grabDetect = GameObject.Find("GrabDetect");
        boxHolder = GameObject.Find("GrabHolder");
        ObjectLayer = LayerMask.GetMask("ObjectLayer");
    }
    #endregion

    #region Update_funcionamento
    private void Update()
    { 
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.transform.position, grabDetect.transform.right, rayDist, ObjectLayer);
        Debug.DrawRay(grabDetect.transform.position, grabDetect.transform.right * rayDist, Color.green);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Object" && pegou == false)
        {
            ObjectPoly = grabCheck.collider.gameObject.GetComponent<PolygonCollider2D>();
            objectGO = grabCheck.collider.gameObject;
            HitObjeto = true;
            if (Time.time >= NextattackTime && Time.time >= NextattackTime)
            {
                if (Input.GetKeyDown(KeyCode.J) && pegou == false)
                {
                    grabCheck.collider.gameObject.transform.SetParent(boxHolder.transform.parent);
                    grabCheck.collider.gameObject.transform.position = boxHolder.transform.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    ObjectPoly.enabled = false;
                    PlayerAni.SetBool("Holding", true);
                    pegou = true;
                    pegouNum = pegouNum + 1;
                    NextattackTime = Time.time + 1f / attackRate;
                }
            }
            else if (grabCheck.collider == null && pegou == false)
            {
                HitObjeto = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) && pegou == true)
        {
            ObjectPoly.enabled = true;
            Debug.Log("Entrou no jogar objeto");
            objectGO.transform.parent = null;
            objectRB = objectGO.GetComponent<Rigidbody2D>();
            objectRB.isKinematic = false;
            PlayerAni.SetBool("Holding", false);
            objectRB.AddForce(boxHolder.transform.right * force);
            objectRB.AddForce(boxHolder.transform.up * 10);
            HitObjeto = false;
            Invoke("PegouFalse", .400f);
        }
    }
    #endregion

    #region métodos
    void PegouFalse()
    {
        pegou = false;
    }
    #endregion
}
