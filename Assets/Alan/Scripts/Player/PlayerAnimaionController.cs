using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaionController : MonoBehaviour
{
    public float rayDist;

    Animator PlayerAnimator;
    GameObject boxDetect;
    LayerMask ObjectLayer;


    private void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        boxDetect = GameObject.Find("BoxDetect");
        ObjectLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(boxDetect.transform.position, boxDetect.transform.right, rayDist, ObjectLayer);
        Debug.DrawRay(boxDetect.transform.position, boxDetect.transform.right * rayDist, Color.yellow);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            PlayerAnimator.SetBool("IsPushing", true);
        }
        else
        {
            PlayerAnimator.SetBool("IsPushing", false);
        }
    }
}
