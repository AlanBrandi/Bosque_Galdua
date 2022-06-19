using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    
    public Slider healthBar;
    public ScreenShakeController screenShake;

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
    public bool CanTakeDamage = true;
     
    float nextAttack = 0f;

    public BossScript bossScript;
    public Animator anim;

    int chooseStatee;
    public int idleNumber;

    public MyHealthSystem PlayerHP;

    int contS = 0;
    int contA = 0;
    int contL = 0;
    int contSlam;

    


    private void Start()
    {
        anim = this.GetComponent<Animator>();
        idleNumber = Animator.StringToHash("BossIdle");
        
    }

    private void Update()
    {
        
        
        if (Time.time > nextAttack)
        {
            bossScript.dano = 2;

            nextAttack = Time.time + attackrate;
            if(contA >= 2)
            {
                chooseStatee = 2;
                chooseState();
            }
            else if(contL >= 2)
            {
                chooseStatee = 3;
                chooseState();
            }
            else if(contS >= 2)
            {
                chooseStatee = 1;
                chooseState();
            }
            else if(contSlam >= 2)
            {
                chooseStatee = 0;
                chooseState();
            }
            else if(contA < 2 && contL < 2 && contS < 2 && contSlam < 2)
            {
                RandomState();
            }
                
                      
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

    public void Slam()
    {
        
        anim.SetTrigger("SlamAttack");
       
    }
    public void laser()
    {
        Debug.Log("LAZER ATTACK");
        anim.SetTrigger("Laser");
    }

    public void shake1()
    {
        screenShake.startShake(.5f, 1f);
    }
    public void shake2()
    {
        screenShake.startShake(1f, 3f);
        CanTakeDamage = false;
        Invoke("CanTakeDamageTrue", 10);
        
    }
    public void CanTakeDamageTrue()
    {
        CanTakeDamage = true;
    }
    public void SetDamage()
    {
        bossScript.dano = 4;
    }


    public void RandomState()
    {
        
        randomState = Random.Range(0, 4);
        if (randomState == 0)
        {
            contS++;
            contSlam = 0;
            contA = 0;
            contL = 0;
            attackrate = 10;
            summonAnim();
        }
        else if (randomState == 1)
        {
            contA++;
            contSlam = 0;
            contS = 0;
            contL = 0;
            attackrate = 8.5f;
            shockWaveAnim();
        }
        else if (randomState == 2)
        {
            contL++;
            contSlam = 0;
            contS = 0;
            contA = 0;
            attackrate = 5.5f;
            laser();
        }
        else if (randomState == 3)
        {
            contSlam++;
            contA = 0;
            contL = 0;
            contS = 0;
            attackrate = 10;
            Slam();
        }

        

    }
    public void chooseState()
    {

        if (chooseStatee == 0)
        {
            contS++;
            contSlam = 0;
            contA = 0;
            contL = 0;
            attackrate = 10;
            summonAnim();
        }
        else if (chooseStatee == 1)
        {
            contA++;
            contSlam = 0;
            contS = 0;
            contL = 0;
            attackrate = 8.5f;
            shockWaveAnim();
        }
        else if (chooseStatee == 2)
        {
            contL++;
            contSlam = 0;
            contS = 0;
            contA = 0;
            attackrate = 5;
            laser();
        }
        else if (chooseStatee == 3)
        {
            contSlam++;
            contA = 0;
            contL = 0;
            contS = 0;
            attackrate = 10;
            Slam();
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
