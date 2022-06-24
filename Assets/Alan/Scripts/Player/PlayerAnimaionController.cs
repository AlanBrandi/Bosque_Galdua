using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaionController : MonoBehaviour
{
    public float rayDist;

    Animator PlayerAnimator;
    GameObject boxDetect;
    public LayerMask ObjectLayer;


    private void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        boxDetect = GameObject.Find("BoxDetect");
    }

    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(boxDetect.transform.position, boxDetect.transform.right, rayDist, ObjectLayer);
        Debug.DrawRay(boxDetect.transform.position, boxDetect.transform.right * rayDist, Color.yellow);

        if (grabCheck.collider != null && !PlayerAnimator.GetBool("IsJumping"))
        {
            PlayerAnimator.SetBool("IsPushing", true);
        }
        else
        {
            PlayerAnimator.SetBool("IsPushing", false);
        }
    }
}
