using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectScript : MonoBehaviour
{
    GameObject grabDetect;
    GameObject boxHolder;
    LayerMask ObjectLayer;
    public float rayDist;

    Rigidbody2D objectRB;

    public Animator PlayerAni;
    public float force = 5;
    public bool HitObjeto = false;
    public bool pegou = false;
    public int pegouNum = 0;
    private void Awake()
    {
        grabDetect = GameObject.Find("GrabDetect");
        boxHolder = GameObject.Find("GrabHolder");
        ObjectLayer = LayerMask.GetMask("ObjectLayer");
    }
   
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.transform.position, Vector2.right * transform.rotation.y, rayDist, ObjectLayer);
      
        if (grabCheck.collider != null && grabCheck.collider.tag == "Object")
        {
            HitObjeto = true;
            if (Input.GetKeyDown(KeyCode.J) && pegou == false)
            {
                grabCheck.collider.gameObject.transform.SetParent(boxHolder.transform.parent);
                grabCheck.collider.gameObject.transform.position = boxHolder.transform.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                PlayerAni.SetBool("Holding",true);
                pegou = true;
                pegouNum++;
            }
            else if (Input.GetKeyDown(KeyCode.J) && pegou == true)
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                pegou=false;
                PlayerAni.SetBool("Holding", false);
                //fazer ele jogar o obj
                objectRB = grabCheck.collider.GetComponent<Rigidbody2D>();
                objectRB.AddForce( boxHolder.transform.right * force);
                objectRB.AddForce(boxHolder.transform.up * 10);
                HitObjeto = false;
            }
        }
        else if (grabCheck.collider == null || grabCheck.collider.tag != "Object")
        {
            HitObjeto = false;
        }
    }
    






}
