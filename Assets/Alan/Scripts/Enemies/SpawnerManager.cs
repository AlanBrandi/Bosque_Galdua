using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject Enemy;
    float randX;
    float randY;
    Vector2 WhereToSpawn;
    public float SpawnRate = 2f;
    float NextSpawn;
    Transform where;

    private void Start()
    {
        where = this.GetComponent<Transform>();
    }
    private void Update()
    {
        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            randX = Random.Range(-0.5f, 0.5f);
            randY = Random.Range(-2, 2);
            WhereToSpawn = new Vector2((where.position.x + randX), (where.position.y + randY));
            Instantiate(Enemy, WhereToSpawn, Quaternion.identity);
        }
    }
}
