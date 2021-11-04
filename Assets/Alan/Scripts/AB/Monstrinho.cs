using UnityEngine;

public class Monstrinho : SpawnerManager
{
    public int dano = 5;
    public float moveSpeed = 5f;
    private GameObject Player;
    private MyHealthSystem PlayerHP;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        rb.velocity = direction*moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player.GetComponent<MyHealthSystem>().Dano(dano);
        }
    }
}