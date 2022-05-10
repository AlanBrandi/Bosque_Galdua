using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public Transform[] transforms;
    public float waitTime = 1;

    Vector3 nextPos;

    void Start()
    {
        transforms = GetComponentsInChildren<Transform>();
        nextPos = transforms[3].position;
    }
    private void FixedUpdate()
    {
        if (transforms[2].transform.position == transforms[3].position)
        {
            nextPos = transforms[4].position;
        }
        else if (transforms[2].transform.position == transforms[4].position)
        {
            nextPos = transforms[3].position;
        }
        transforms[1].transform.position = Vector3.MoveTowards(transforms[1].transform.position, nextPos, speed * Time.fixedDeltaTime);
    }
}
