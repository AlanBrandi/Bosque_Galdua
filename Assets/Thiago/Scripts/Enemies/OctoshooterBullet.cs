using UnityEngine;

public class OctoshooterBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D bulletRb;
    private Octoshooter octo;

    private void Start()
    {
        octo = GameObject.FindGameObjectWithTag("Octoshooter").GetComponent<Octoshooter>();
        bulletRb = GetComponent<Rigidbody2D>();
        int direction = octo.facingRight ? 1 : -1;
        Vector2 moveDir = new Vector2(direction * speed, 0);
        if (octo.facingRight)
        {
            bulletRb.velocity = new Vector2(Mathf.Abs(moveDir.x), moveDir.y);
        }
        else
        {
            bulletRb.velocity = new Vector2(-Mathf.Abs(moveDir.x), moveDir.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
