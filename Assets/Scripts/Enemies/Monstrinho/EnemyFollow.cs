using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Transform target;
    public float speed;
    Transform MyTransform;

    void Start()
    {
        MyTransform = this.GetComponent<Transform>();
        target = transform.Find("Player");
    }

   
    void Update()
    {
        MyTransform.position = Vector2.MoveTowards(MyTransform.position, target.position, speed + Time.deltaTime); 
    }
}
