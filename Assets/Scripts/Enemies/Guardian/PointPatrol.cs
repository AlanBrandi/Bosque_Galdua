using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPatrol : MonoBehaviour
{
    public float speed = 5;
    public float repeatRate = 3;
    public GameObject[] points;
    int index = 0;
    EnemyGFX enemyGFX;
    [HideInInspector] public Vector2 targetPosition;
    Vector3 direction;
    Vector3 velocity;
    Vector3 desired_velocity;
    Vector3 steering_velocity;
    public float mass = 10;
    

    private void Start()
    {
        enemyGFX = GetComponentInChildren<EnemyGFX>();
        InvokeRepeating("ChangePoint", 0, repeatRate);
        if (transform.rotation.y == 0)
        {
            enemyGFX.facingRight = true;
        }
        enemyGFX.Flip('p');
    }

    private void Update()
    {
        direction = ((Vector3)targetPosition - transform.position).normalized;
        desired_velocity = direction * speed * Time.deltaTime;
        steering_velocity = desired_velocity - velocity;
        steering_velocity = steering_velocity / mass;
        velocity = velocity + steering_velocity;

        if (Vector2.Distance(targetPosition, transform.position) > 0.5f)
        {
            transform.position += velocity;
        }
    }
   
    void ChangePoint()
    {
        index++;
        if (index >= points.Length)
        {
            index = 0;
        }
        targetPosition = points[index].transform.position;
        enemyGFX.Flip('p');
    }
}
