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
    public bool canStart;

    int chooseStatee;
    public int idleNumber;

    public MyHealthSystem PlayerHP;

    


    private void Start()
    {
        healthBar.gameObject.SetActive(false);
        anim = this.GetComponent<Animator>();
        idleNumber = Animator.StringToHash("BossIdle");
        
    }

    private void Update()
    {
        anim.SetFloat("BossLife", bossScript.BosscurrentHealth);
        if (canStart)
        {
            spawnHealthBar();


            if (Time.time > nextAttack)
            {
                bossScript.dano = 2;

                nextAttack = Time.time + attackrate;

                    RandomState();
                


            }
        }               
    }

    public void spawnHealthBar()
    {
        healthBar.gameObject.SetActive(true);
    }
    
    public void summonAnim()
    {
        Debug.Log("SUMMON ATTACK");

            anim.SetTrigger("Summon");

    }

    public void summonFase1()
    {
        Instantiate(summonAttack1, summonAttackPos.transform.position, Quaternion.identity);
        summonAttack.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    public void summonFase2()
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
        Invoke("CanTakeDamageFalse", 0.4f);
    }
    public void CanTakeDamageTrue()
    {
        CanTakeDamage = true;
    }
    public void CanTakeDamageFalse()
    {
        CanTakeDamage = false;
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

            attackrate = 10;
            summonAnim();
        }
        else if (randomState == 1)
        {

            attackrate = 4.0f;
            shockWaveAnim();
        }
        else if (randomState == 2)
        {

            attackrate = 10;
            Slam();
        }
        else if (randomState == 3)
        {

            attackrate = 4.0f;
            laser();
            
        }




    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NUIXNSOUXNC");
        if (collision.CompareTag("PlayerManager"))
        {
            PlayerHP.Dano(2);
            
            
        }
    }

}
