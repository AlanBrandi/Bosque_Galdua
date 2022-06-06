using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackPlayer : MonoBehaviour
{
    public Transform center;
    public float knockbackVel;
    public float knockbackTime;
    public bool knockbacked;
    public void knockback(Transform t)
    {
        var dir = transform.position - t.position;
        Debug.Log(dir);
    }
    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        knockbacked = false;
    }
}
