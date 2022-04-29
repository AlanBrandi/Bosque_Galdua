using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPatrol : MonoBehaviour
{
    public float speed = 5;
    public GameObject[] points;
    int index = 0;
    EnemyGFX enemyGFX;

    Vector2 targetPosition;
    Vector3 direction;
    Vector3 velocity;
    Vector3 desired_velocity;
    Vector3 steering_velocity;
    public float mass = 10;

    private void Start()
    {
        enemyGFX = GetComponentInChildren<EnemyGFX>();
        enemyGFX.Rotate();
        InvokeRepeating("ChangePoint", 0, 3);
    }

    private void Update()
    {
        direction = ((Vector3)targetPosition - transform.position).normalized;
        desired_velocity = direction * speed * Time.deltaTime;
        steering_velocity = desired_velocity - velocity;
        steering_velocity = steering_velocity / mass;
        velocity = velocity + steering_velocity;

        if (Vector2.Distance(targetPosition, transform.position) > 0.5f)
            transform.position += velocity;
    }

    void ChangePoint()
    {
        enemyGFX.Rotate();
        index++;
        if (index >= points.Length)
        {
            index = 0;
        }
        targetPosition = points[index].transform.position;
    }
}
