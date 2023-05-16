using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private GameObject Player;
    public int dano;
    public GameObject efeito;
    PlayerHealth health;
    AudioSource audioSource;
    AudioClip barrelImpact;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = MyHealthSystem.FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
        barrelImpact = Resources.Load("barrel_impact") as AudioClip;
       // Destroy(gameObject, 6f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            health.Hit(dano);
            Instantiate(efeito, transform.position, Quaternion.identity);
            Destroy(gameObject);
            var player = GameObject.FindGameObjectWithTag("PlayerManager").GetComponentInChildren<knockbackPlayer>();
            if (player != null)
            {
                player.knockback(transform);
            }
            
        }
        else if (collision.collider.CompareTag("Object"))
        {
            Instantiate(efeito, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.relativeVelocity.magnitude > 10)
        {
            if (gameObject != null)
            {
                    audioSource.PlayOneShot(barrelImpact, collision.relativeVelocity.magnitude / 10);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            Instantiate(efeito, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}