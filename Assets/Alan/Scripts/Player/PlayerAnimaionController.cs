using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaionController : MonoBehaviour
{
    [SerializeField] float rayDist;

    Animator playerAnimator;
    GameObject boxDetect;
    [SerializeField] LayerMask objectLayer;


    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        boxDetect = GameObject.Find("BoxDetect");
    }

    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(boxDetect.transform.position, boxDetect.transform.right, rayDist, objectLayer);
        Debug.DrawRay(boxDetect.transform.position, boxDetect.transform.right * rayDist, Color.yellow);

        if (grabCheck.collider != null && !playerAnimator.GetBool("IsJumping"))
        {
            playerAnimator.SetBool("IsPushing", true);
        }
        else
        {
            playerAnimator.SetBool("IsPushing", false);
        }
    }
}
