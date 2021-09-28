using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{
    public GameObject Enemy;
    private float X;
    private float Y;
    private Vector2 WhereToSpawn;
    public float SpawnRate = 2f;
    private float NextSpawn;
    private Transform where;

    private void Start()
    {
        where = this.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            WhereToSpawn = new Vector2((where.position.x), (where.position.y));
            Instantiate(Enemy, WhereToSpawn, Quaternion.identity);
        }
    }
}