using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackPlayer : MonoBehaviour
{
    public Transform center;
    public float knockbackVel;
    public float knockbackTime;
    public bool knockbacked;
    public Moving move;
    public void knockback(Transform t)
    {
        move.stopMove();
        var dir = transform.position - t.position;
        Debug.DrawRay(transform.position, dir, Color.red, 1f);
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * knockbackVel, ForceMode2D.Impulse);
        StartCoroutine(Unknockback());
        knockbacked = true;
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        move.canMove = true;
        knockbacked = false;
    }
}
