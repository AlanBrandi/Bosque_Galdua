using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private GameObject Player;
    public int dano;
    public GameObject efeito;
    MyHealthSystem health;
    AudioSource audioSource;
    public AudioClip barrel_impact;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = MyHealthSystem.FindObjectOfType<MyHealthSystem>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = barrel_impact;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            health.Dano(dano);
            Instantiate(efeito, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.relativeVelocity.magnitude > 10)
        {
            audioSource.PlayOneShot(barrel_impact, collision.relativeVelocity.magnitude/10);
        }
    }
}