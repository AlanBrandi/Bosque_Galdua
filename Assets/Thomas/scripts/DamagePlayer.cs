using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private GameObject Player;
    public int dano;
    public GameObject efeito;
    MyHealthSystem health;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = MyHealthSystem.FindObjectOfType<MyHealthSystem>();
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
    }

   
}