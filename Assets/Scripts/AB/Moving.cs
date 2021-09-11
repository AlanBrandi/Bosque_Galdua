using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Transform Pl_Transform;
    public KeyCode T_Direita;
    public KeyCode T_Esquerda;
    public Animator MyAnimator;
    public Rigidbody2D MyRb;
    public float MovementSpeed = 1;
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(!Mathf.Approximately(0, movement))
        {
           Pl_Transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }


        if (Input.GetKeyDown(T_Direita))
        {
            MyAnimator.SetTrigger("Walking");
        }

        if (Input.GetKeyUp(T_Direita))
        {
            MyAnimator.SetTrigger("Idle");
        }

        if (Input.GetKeyDown(T_Esquerda))
        {
            MyAnimator.SetTrigger("Walking");
        }

        if (Input.GetKeyUp(T_Esquerda))
        {
            MyAnimator.SetTrigger("Idle");
        }
    }
}
