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
    public Transform Player;

    private void Start()
    {
        waiTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    private void Update()
    {
       Move();
       if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waiTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waiTime = startWaitTime;
            }
            else
            {
                waiTime -= Time.deltaTime;
            }
        }
    }
    public void Move()
    {
        float distanceFromPlayerup = Vector2.Distance(Player.position, transform.position);
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
}
