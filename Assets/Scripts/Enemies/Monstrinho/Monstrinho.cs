using UnityEngine;

public class Monstrinho : SpawnerManager
{
    public int dano = 1;
    public float moveSpeed = 5f;
    private GameObject Player;
    public MyHealthSystem PlayerHP;
    private Vector2 movement;
    private Rigidbody2D rb;
            EnemiesScript enemy;
    AudioSource enemy3;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        Player = GameObject.FindGameObjectWithTag("Player");

        PlayerHP = MyHealthSystem.FindObjectOfType<MyHealthSystem>();

        enemy = GetComponent<EnemiesScript>();

        enemy3 = GetComponent<AudioSource>();

        InvokeRepeating("ConstantSound", 0f, 0.3f);
    }

    private void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        rb.velocity = direction*moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHP.Dano(dano);
            enemy.TakeDamage(enemy.maxHealth);
            Destroy(this.gameObject);
        }
    }

    void ConstantSound()
    {
        float randomPitch = Random.Range(0.9f, 1f);
        enemy3.pitch = randomPitch;
        enemy3.Play();
    }
}