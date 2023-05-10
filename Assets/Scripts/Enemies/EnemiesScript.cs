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
    PlayerHealth myHealthSystem;
    public float knockbackForce;
    public float knockbackForceUp;
    public bool knockbacked;
    Rigidbody2D rb;
    public ScreenShakeController screenShake;

    public SimpleFlash flash;


    //public GameObject monster;
    private void Awake()
    {
        myHealthSystem = GameObject.FindObjectOfType<PlayerHealth>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();  
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

       
        if (sceneName == "BossLevel")
        {
            screenShake.startShake(.5f, 0.7f);
            screenShake = GameObject.FindGameObjectWithTag("BossCam").GetComponent<ScreenShakeController>();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
        if(flash != null)
        {
            flash.Flash();
            screenShake.startShake(.35f, 0.5f);
        }
        Debug.Log("Damage!");
        if (currentHealth <= 0)
        {

            Die();
        }
    }
    void Die()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        screenShake.startShake(.5f, 0.7f);
        if(sceneName == "BossLevel")
        {
            Instantiate(barril, whereToAddEffect.position, Quaternion.identity);
        }
        Instantiate(fxDie, whereToAddEffect.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dano > 0)
        {
            var player = GameObject.FindGameObjectWithTag("PlayerManager").GetComponentInChildren<knockbackPlayer>();
            if (player != null)
            {
                player.knockback(transform);
            }
            myHealthSystem.Hit(dano);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && dano > 0)
        {
            var player = GameObject.FindGameObjectWithTag("PlayerManager").GetComponentInChildren<knockbackPlayer>();
            if (player != null)
            {
                player.knockback(transform);
            }
            myHealthSystem.Hit(dano);
        }
    }
    public void knockback()
    {
        Transform attacker = getClosestDamageSource();
        Vector2 knockbackDirection = new Vector2(transform.position.x - attacker.position.x, 0);
        rb.AddForce(new Vector2(knockbackDirection.x, knockbackForceUp) * knockbackForce) ;
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