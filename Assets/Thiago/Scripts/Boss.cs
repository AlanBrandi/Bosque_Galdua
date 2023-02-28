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
    public BossSfx sfx;

    float nextAttack = 0f;

    public BossScript bossScript;
    public Animator anim;
    public bool canStart;

    int chooseStatee;
    public int idleNumber;

    public MyHealthSystem PlayerHP;

    int shock;
    int slam;
    int summon;

    public DetectPlayer playerDetection;
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

        Debug.Log("SUMMON");
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
        Debug.Log("SHOCK");
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
        Debug.Log("SLAM");
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
        if (playerDetection.playerIsHere)
        {
            Debug.Log("PLATFORMSPIN");
            anim.SetTrigger("PlatformSpin");
        }
        else
        {


            randomState = Random.Range(0, 4);
            if (randomState == 0)
            {

                attackrate = 5.0f;
                if (summon > 2)
                {
                    shock = 0;
                    summon = 0;
                    Slam();
                    slam++;
                }
                else
                {
                    shock = 0;
                    slam = 0;
                    summonAnim();
                    summon++;
                }
            }
            else if (randomState == 1)
            {

                attackrate = 3.0f;
                if (shock > 2)
                {
                    summon = 0;
                    shock = 0;
                    Slam();
                    slam++;
                }
                else
                {
                    summon = 0;
                    slam = 0;
                    shockWaveAnim();
                    shock++;
                }

            }
            else if (randomState == 2)
            {

                attackrate = 5.0f;
                if (slam > 2)
                {
                    int randomState2 = Random.Range(0, 2);
                    if (randomState2 == 0)
                    {
                        shock = 0;
                        slam = 0;
                        summonAnim();
                        summon++;
                    }
                    else
                    {
                        summon = 0;
                        slam = 0;
                        shockWaveAnim();
                        shock++;
                    }
                }
                else
                {
                    summon = 0;
                    shock = 0;
                    Slam();
                    slam++;
                }

            }
            else if (randomState == 3)
            {

                attackrate = 4.0f;
                laser();

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerManager"))
        {
            PlayerHP.Dano(2);
        }
    }

    public void dyingSfx()
    {
        sfx.audio.PlayOneShot(sfx.bossDying);
    }
    public void aisingSfx()
    {
        sfx.audio.PlayOneShot(sfx.raisingArm);
    }
    public void attackWaveSfx()
    {
        sfx.audio.PlayOneShot(sfx.bossAttackWave);
    }
    public void attackSlamSfx()
    {
        sfx.audio.PlayOneShot(sfx.bossAttackSlam);
    }
    public void summonSfx()
    {
        sfx.audio.PlayOneShot(sfx.bossSummon);
    }
    public void laserSfx()
    {
        sfx.audio.PlayOneShot(sfx.laser);
    }
    public void takeHitSfx()
    {
        sfx.audio.PlayOneShot(sfx.takeHit);
    }
    public void spawnSfx()
    {
        sfx.audio.PlayOneShot(sfx.spawn);
    }
}
