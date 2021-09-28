using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private GameObject Player;
    public int dano;
    public GameObject efeito;
    

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player.GetComponent<MyHealthSystem>().Dano(dano);
            Instantiate(efeito, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

   
}