using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPatrol : MonoBehaviour
{
    public float speed = 5;
    public GameObject[] points;
    int index = 0;
    EnemyGFX enemyGFX;
    GameObject EnemyGfxGO;
    public bool facingRight = true;
    Vector2 targetPosition;
    Vector3 direction;
    Vector3 velocity;
    Vector3 desired_velocity;
    Vector3 steering_velocity;
    public float mass = 10;
    float PointPosition;

    private void Start()
    {
        EnemyGfxGO = GameObject.Find("GuardianGFX");
        enemyGFX = GetComponentInChildren<EnemyGFX>();
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
        FlipsTowardsPoint();
        Debug.Log(targetPosition.x);
    }
   
    void ChangePoint()
    {
        index++;
        if (index >= points.Length)
        {
            index = 0;
        }
        targetPosition = points[index].transform.position;
       // PointPosition = points[index].transform.position.x;
    }

    void Flip()
    {
        if (facingRight)
        {
            EnemyGfxGO.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;

        }
        else if (!facingRight)
        {
            EnemyGfxGO.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }

    }
    void FlipsTowardsPoint()
    {
        PointPosition = targetPosition.x - EnemyGfxGO.transform.position.x;
        if (PointPosition < 0 && facingRight)
        {
            Debug.Log("VAI PRA ESQUERDA");
            Flip();
        }
        else if (PointPosition > 0 && !facingRight)
        {
            Debug.Log("VAI PRA DIREITA");
            Flip();
        }
    }
}
