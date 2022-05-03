using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject target;
    public float speedUp;
    public float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        

    }
    private void Start()
    {

        StartCoroutine(bomb());
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator bomb()
    {
        var direction = -transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(direction * speedUp, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.1f);

        GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position) * speed, ForceMode2D.Impulse);
    }
}
