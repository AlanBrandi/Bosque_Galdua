using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemiesScript : MonoBehaviour
{
    public int maxHealth = 20;
    public int dano;
    public int currentHealth;
    public GameObject fxDie;
    public GameObject fxHit;
    public GameObject barril;
    public Transform whereToAddEffect;
    Transform customWhereToAdd;
    MyHealthSystem myHealthSystem;
    public float knockbackForce;
    public float knockbackForceUp;
    public bool knockbacked;
    Rigidbody2D rb;
    public ScreenShakeController screenShake;
    Scene sceneName;

    //public GameObject monster;
    void Start()
    {
        myHealthSystem = GameObject.FindObjectOfType<MyHealthSystem>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        screenShake = GameObject.FindGameObjectWithTag("BossCam").GetComponent<ScreenShakeController>();
    }

    public void TakeDamage(int damage)
    {
        knockback();
        currentHealth -= damage;
        Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
        Debug.Log("Damage!");
        if (currentHealth <= 0)
        {

            Die();
        }

    }
    void Die()
    {
        if(sceneName.name == "BossLevel")
        {
            screenShake.startShake(.2f, 0.5f);
            Instantiate(barril, whereToAddEffect.position, Quaternion.identity);
        }
        Instantiate(fxDie, whereToAddEffect.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dano > 0)
        {
            Debug.Log("Inimigo deu dano em player.");
            myHealthSystem.Dano(dano);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dano > 0)
        {
            Debug.Log("Inimigo deu dano em player.");
            myHealthSystem.Dano(dano);
        }
    }
    public void knockback()
    {
        Transform attacker = getClosestDamageSource();
        Vector2 knockbackDirection = new Vector2(transform.position.x - attacker.position.x, 0);
        rb.velocity = new Vector2(knockbackDirection.x, knockbackForceUp) * knockbackForce;

    }
    public Transform getClosestDamageSource()
    {
        GameObject[] DamageSources = GameObject.FindGameObjectsWithTag("Player");
        float closestDistance = Mathf.Infinity;
        Transform currentClosestDamageSource = null;
        foreach (GameObject go in DamageSources)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                currentClosestDamageSource = go.transform;
            }
        }
        return currentClosestDamageSource;
    }
}