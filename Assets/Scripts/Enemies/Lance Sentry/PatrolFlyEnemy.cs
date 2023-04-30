using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFlyEnemy : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;
    public float speed;
    public float lineOfSite;
    private float waiTime;
    public float startWaitTime;
    Rigidbody2D enemyRb;
    public GameObject Player;
    int cont = 0;
    Lance_Sentry attackScript;

    private void Start()
    {
        waiTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        enemyRb = GetComponent<Rigidbody2D>();
        attackScript = GetComponent<Lance_Sentry>();
    }
    private void Update()
    {
        if(cont < 5)
        {
            Move();
        }
       
       if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waiTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waiTime = startWaitTime;
                cont++;
                if(cont >= 5)
                {
                    Stop();
                   // attackScript.RandomState();
                    cont = 0;
                    Invoke("Stop", 1.5f);
                    
                    Move();
                }
                
            }
            else
            {
                waiTime -= Time.deltaTime;
            }
        }
    }
    public void Move()
    {
        float distanceFromPlayerup = Vector2.Distance(Player.transform.position, transform.position);
        if(distanceFromPlayerup < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        }

        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
    public void Stop()
    {
        enemyRb.velocity = Vector2.zero;
    }

}
