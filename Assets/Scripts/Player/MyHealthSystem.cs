using UnityEngine;

public class MyHealthSystem : MonoBehaviour, IDataPersistence
{
    GameObject PlayerGO;
    GameObject playerManager;
    public Material DefautMaterial;
    public Material HitMaterial;
    public float Time_frame = 1;
    float remainingIF;
    public bool PlayerTomouDano = false;

    GameData_SO gd;

    SpriteRenderer Head;
    SpriteRenderer RightHand;
    SpriteRenderer LeftHand;
    SpriteRenderer RightFoot;
    SpriteRenderer LeftFoot;
    SpriteRenderer Sword;

    bool Blink = false;

    GameObject Hit;
    Animator hitAnim;
    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        Hit = GameObject.Find("HitHUD");
        Head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
        RightHand = GameObject.Find("RightHand").GetComponent<SpriteRenderer>();
        LeftHand = GameObject.Find("LeftHand").GetComponent<SpriteRenderer>();
        RightFoot = GameObject.Find("RightHand").GetComponent<SpriteRenderer>();
        LeftFoot = GameObject.Find("LeftFoot").GetComponent<SpriteRenderer>();
        Sword = GameObject.Find("Sword").GetComponent<SpriteRenderer>();
        hitAnim = Hit.GetComponentInChildren<Animator>();
        Hit.SetActive(false);
    }
    private void Update()
    {

        if (GameManager.Instance.playerLives.lives <= 0)
        {
            Die();
        }
        if (Blink == true)
        {
        }
        else
        {
            TomouDanofalso();
        }
    }
    public void Dano(int dano)
    {
        /*if(PlayerTomouDano == true)
        {
            Invoke("TomouDanofalso", Time_frame);
        }
        else */
        if (PlayerTomouDano == false)
        {
            GameManager.Instance.DecreaseLife(dano);
            Hit.SetActive(true);
            hitAnim.SetTrigger("PlayerHit");
            PlayerTomouDano = true;
            remainingIF = Time_frame;
            Blink = true;

            //---------FICAR TRANSPARENTE-------------

            Head.color = new Color(1, 1, 1, .7f);
            RightHand.color = new Color(1, 1, 1, .7f);
            LeftHand.color = new Color(1, 1, 1, .7f);
            RightFoot.color = new Color(1, 1, 1, .7f);
            LeftFoot.color = new Color(1, 1, 1, .7f);
            Sword.color = new Color(1, 1, 1, .7f);

            Invoke(nameof(DisableHit), 1);
            PiscarOn();
            Invoke("TomouDanofalso", Time_frame);

            return;
        }
    }
    public void Die()
    {
        playerManager.GetComponent<Moving>().enabled = false;
        playerManager.GetComponent<PlayerAttack>().enabled = false;
        playerManager.GetComponent<PlayerHighAttack>().enabled = false;
        playerManager.GetComponent<Jumping>().enabled = false;
        playerManager.SetActive(false);
        GameManager.Instance.DecreaseLife(0);
    }
    void TomouDanofalso()
    {

        Head.color = new Color(1, 1, 1, 1);
        RightHand.color = new Color(1, 1, 1, 1);
        LeftHand.color = new Color(1, 1, 1, 1);
        RightFoot.color = new Color(1, 1, 1, 1);
        LeftFoot.color = new Color(1, 1, 1, 1);
        Sword.color = new Color(1, 1, 1, 1);
        Blink = false;
        PlayerTomouDano = false;
    }
    void DisableHit()
    {
        Hit.SetActive(false);
    }
    void PiscarOn()
    {
        if (Blink == false)
        {
            Head.color = new Color(1, 1, 1, 1);
            RightHand.color = new Color(1, 1, 1, 1);
            LeftHand.color = new Color(1, 1, 1, 1);
            RightFoot.color = new Color(1, 1, 1, 1);
            LeftFoot.color = new Color(1, 1, 1, 1);
            Sword.color = new Color(1, 1, 1, 1);
        }
        else
        {
            // Cor
            Head.material = HitMaterial;
            RightHand.material = HitMaterial;
            LeftHand.material = HitMaterial;
            RightFoot.material = HitMaterial;
            LeftFoot.material = HitMaterial;
            Sword.material = HitMaterial;
            //Transparente
            /*Head.color = new Color(1, 1, 1, .3f);
            Right_hand.color = new Color(1, 1, 1, .3f);
            Left_hand.color = new Color(1, 1, 1, .3f);
            Right_foot.color = new Color(1, 1, 1, .3f);
            Left_foot.color = new Color(1, 1, 1, .3f);
            Sword.color = new Color(1, 1, 1, .3f);*/
            remainingIF -= .075f;
            Invoke("PiscarOff", (5 / remainingIF) * Time.fixedDeltaTime);
        }
    }
    void PiscarOff()
    {
        //Cor
        Head.material = DefautMaterial;
        RightHand.material = DefautMaterial;
        LeftHand.material = DefautMaterial;
        RightFoot.material = DefautMaterial;
        LeftFoot.material = DefautMaterial;
        Sword.material = DefautMaterial;

        //Transparente
        /*Head.color = new Color(1, 1, 1, 1);
        Right_hand.color = new Color(1, 1, 1, 1);
        Left_hand.color = new Color(1, 1, 1, 1);
        Right_foot.color = new Color(1, 1, 1, 1);
        Left_foot.color = new Color(1, 1, 1, 1);
        Sword.color = new Color(1, 1, 1, 1);*/

        remainingIF -= .075f;
        Invoke("PiscarOn", (5 / remainingIF) * Time.fixedDeltaTime);
    }

    public void LoadData(GameData data)
    {
        GameManager.Instance.playerLives.lives = data.lives;
    }

    public void SaveData(ref GameData data)
    {
        data.lives = GameManager.Instance.playerLives.lives;
    }
}