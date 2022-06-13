using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    
    public Slider healthBar;
    public int currentHealth;

    GameObject FireAttack;
    public GameObject shockWaveAttack;
    public GameObject summonAttack;
    public GameObject summonAttack1;
    public Transform summonAttackPos;
    public Transform summonAttackPos1;
    public Transform summonAttackPos2;
    Transform fireGroundPos;
    public Transform shockwavePos;
    public float attackrate;
    int randomState = 0;
     acidSpawn acid;
    float nextAttack = 0f;
    public float acidRate;
    float nextAcid = 0;
    public Animator anim;
    public bool IsIdle = true;
    int chooseStatee;

    public MyHealthSystem PlayerHP;

    int contS = 0;
    int contA = 0;
    int contL = 0;


    private void Start()
    {
        acid = acid.GetComponent<acidSpawn>();
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        healthBar.value = currentHealth;
        if (Time.time > nextAttack)
        {
          
                nextAttack = Time.time + attackrate;
            if(contA >= 2)
            {
                chooseStatee = 2;
                chooseState();
            }
            else if(contL >= 2)
            {
                chooseStatee = 0;
                chooseState();
            }
            else if(contS >= 2)
            {
                chooseStatee = 1;
                chooseState();
            }
            else if(contA < 2 && contL < 2 && contS < 2)
            {
                RandomState();
            }
                
                      
        }
        if (Time.time > nextAcid && randomState == 3)
        {

            nextAcid = Time.time + acidRate;
            acidRain();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
        }
    }

    public void summonAnim()
    {
        Debug.Log("SUMMON ATTACK");
        anim.SetTrigger("Summon");
    }
    public void summon()
    {
        Instantiate(summonAttack1, summonAttackPos.transform.position, Quaternion.identity);
        Instantiate(summonAttack, summonAttackPos1.transform.position, Quaternion.identity);
        Instantiate(summonAttack1, summonAttackPos2.transform.position, Quaternion.identity);
        summonAttack.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    public void shockWaveAnim()
    {
        Debug.Log("SHOCK WAVE ATTACK");   
        anim.SetTrigger("AttackWave");
    }
    public void shockWave()
    {
        Instantiate(shockWaveAttack, shockwavePos.transform.position, Quaternion.identity);
    }
    public void fireGroundAttack()
    {
        Debug.Log("FIRE ATTACK");
        Instantiate(FireAttack, fireGroundPos.transform.position, Quaternion.identity);
    }

    public void acidRain()
    {
        
       
        acid.acidWave();
        acid.acidgo = true;
       
    }
    public void laser()
    {
        Debug.Log("LAZER ATTACK");
        anim.SetTrigger("Laser");
    }

    public void TakeDamage(int damage)
    {
        
            currentHealth -= damage;
            if (currentHealth > 0)
            {
                anim.SetTrigger("Hurt");
            }
            Debug.Log("Damage!");
        
        

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");
        }

    }
    public void RandomState()
    {
        IsIdle = false;
        randomState = Random.Range(0, 3);
        if (randomState == 0)
        {
            contS++;
            contA = 0;
            contL = 0;
            attackrate = 10;
            summonAnim();
        }
        else if (randomState == 1)
        {
            contA++;
            contS = 0;
            contL = 0;
            attackrate = 10;
            shockWaveAnim();
        }
        else if (randomState == 2)
        {
            contL++;
            contS = 0;
            contA = 0;
            attackrate = 5;
            laser();
        }

        

    }
    public void chooseState()
    {
        
        if (chooseStatee == 0)
        {
            contS++;
            contA = 0;
            contL = 0;
            attackrate = 10;
            summonAnim();
        }
        else if (chooseStatee == 1)
        {
            contA++;
            contS = 0;
            contL = 0;
            attackrate = 10;
            shockWaveAnim();
        }
        else if (chooseStatee == 2)
        {
            contL++;
            contS = 0;
            contA = 0;
            attackrate = 5;
            laser();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHP.Dano(2);
            
            
        }
    }

}
