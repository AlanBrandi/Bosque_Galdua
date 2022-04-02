using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectScript : MonoBehaviour
{
    #region Basics_variable

    public float rayDist;
    public float force = 5;
    public bool pegou = false;
    public bool HitObjeto = false;
    LayerMask ObjectLayer;

    public float AttackRate = 2f;
    public float NextAttackTime = 0f;

    GameObject boxHolder;
    GameObject grabDetect;
    Rigidbody2D objectRB;

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

        if (grabCheck.collider != null && grabCheck.collider.tag == "Object")
        {
            HitObjeto = true;
            if (Time.time >= NextAttackTime && Time.time >= NextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.J) && pegou == false)
                {
                    grabCheck.collider.gameObject.transform.SetParent(boxHolder.transform.parent);
                    grabCheck.collider.gameObject.transform.position = boxHolder.transform.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    PlayerAni.SetBool("Holding", true);
                    pegou = true;
                    pegouNum = pegouNum + 1;
                    NextAttackTime = Time.time + 1f / AttackRate;
                }
                else if (Input.GetKeyDown(KeyCode.J) && pegou == true)
                {
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    PlayerAni.SetBool("Holding", false);
                    objectRB = grabCheck.collider.GetComponent<Rigidbody2D>();
                    objectRB.AddForce(boxHolder.transform.right * force);
                    objectRB.AddForce(boxHolder.transform.up * 10);
                    HitObjeto = false;
                    Invoke("PegouFalse", .400f);
                }
            }
            else if (grabCheck.collider == null)
            {
                HitObjeto = false;
            }
        }
        #endregion
    }
    void PegouFalse()
    {
        pegou = false;
    }
}
