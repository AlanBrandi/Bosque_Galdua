using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int maxHealth = 20;
    public int dano;



    public int BosscurrentHealth;


    MyHealthSystem myHealthSystem;

    Rigidbody2D rb;
    public Boss boss;

    public SimpleFlash flash;
    public SimpleFlash flash2;
    public SimpleFlash flash3;
    public Transform whereToAddEffect;
    public GameObject fxHit;
    public GameObject endMusic;
    public GameObject postMusic;
    //public GameObject monster;
    void Start()
    {
        myHealthSystem = GameObject.FindObjectOfType<MyHealthSystem>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        boss.healthBar.value = BosscurrentHealth;


    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dano > 0 && boss.CanTakeDamage)
        {
            Debug.Log("Inimigo deu dano em player.");
            myHealthSystem.Dano(dano);
        }
    }


    public void TakeDamageByItem(int damage)
    {
        boss.shake1();
        BosscurrentHealth -= damage;
        flash.Flash();
        flash2.Flash();
        flash3.Flash();
        Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
        if (BosscurrentHealth > 10)
        {
            
            if (boss.anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSlam") || boss.anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSlam2"))
            {
                boss.anim.SetTrigger("HurtSlam");
            }
            else
            {
                boss.anim.SetTrigger("Hurt");
            }

        }



        if (BosscurrentHealth <= 10)
        {
            endMusic.SetActive(false);
            postMusic.SetActive(true);
            boss.shake2();
            Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
            boss.anim.SetTrigger("Die");
        }

    }
    public void takeDamageBySword(int damage)
    {
        if (boss.anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSlam") || boss.anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSlam2"))
        {
            boss.shake1();
            BosscurrentHealth -= damage;
            flash.Flash();
            flash2.Flash();
            flash3.Flash();
            Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
            if (BosscurrentHealth > 10)
            {
                
                boss.anim.SetTrigger("HurtSlam");
            }
        }

        if (BosscurrentHealth <= 10)
        {
            boss.shake2();
            Instantiate(fxHit, whereToAddEffect.position, Quaternion.identity);
            endMusic.SetActive(false);
            postMusic.SetActive(true);
            boss.anim.SetTrigger("Die");
        }
    }

}
