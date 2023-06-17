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
    AudioSource barrelLand;
    public int selfDestroyTimer;

    private void Awake()
    {
        where = GetComponent<Transform>();
    }
    void Start()
    {
        barrelLand = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            WhereToSpawn = new Vector2((where.position.x), (where.position.y));
            GameObject enem = Instantiate(Enemy, WhereToSpawn, Quaternion.identity);
            Destroy(enem, selfDestroyTimer);
        }
    }
}