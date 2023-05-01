using UnityEngine;

public class MyHealthSystem : MonoBehaviour//, IDataPersistence
{
    /*
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

    GameObject hitHudFeedback;
    Animator hitAnim;
    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        hitHudFeedback = GameObject.Find("HitHUD");
        Head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
        RightHand = GameObject.Find("RightHand").GetComponent<SpriteRenderer>();
        LeftHand = GameObject.Find("LeftHand").GetComponent<SpriteRenderer>();
        RightFoot = GameObject.Find("RightHand").GetComponent<SpriteRenderer>();
        LeftFoot = GameObject.Find("LeftFoot").GetComponent<SpriteRenderer>();
        hitAnim = hitHudFeedback.GetComponentInChildren<Animator>();
        hitHudFeedback.SetActive(false);
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
        if (PlayerTomouDano == false)
        {
            GameManager.Instance.DecreaseLife(dano);
            hitHudFeedback.SetActive(true);
            hitAnim.SetTrigger("PlayerHit");
            PlayerTomouDano = true;
            remainingIF = Time_frame;
            Blink = true;

            //---------FICAR TRANSPARENTE-------------

            ChangeAlphaPlayer();
            Invoke(nameof(DisableHit), 1);
            PiscarOn();
            Invoke("TomouDanofalso", Time_frame);
            return;
        }
    }
    public void Die()
    {
        DisablePlayerController();
        playerManager.SetActive(false);
        GameManager.Instance.DecreaseLife(0);
    }
    void TomouDanofalso()
    {
        ChangeToDefaultColor();
        Blink = false;
        PlayerTomouDano = false;
    }
    void DisableHit()
    {
        hitHudFeedback.SetActive(false);
    }
    void DisablePlayerController()
    {
        playerManager.GetComponent<Moving>().enabled = false;
        playerManager.GetComponent<PlayerAttack>().enabled = false;
        playerManager.GetComponent<PlayerHighAttack>().enabled = false;
        playerManager.GetComponent<Jumping>().enabled = false;
    }
    void PiscarOn()
    {
        Head.material = HitMaterial;
        RightHand.material = HitMaterial;
        LeftHand.material = HitMaterial;
        RightFoot.material = HitMaterial;
        LeftFoot.material = HitMaterial;
        remainingIF -= .075f;
        Invoke("PiscarOff", (5 / remainingIF) * Time.fixedDeltaTime);
    }
    void PiscarOff()
    {
        Head.material = DefautMaterial;
        RightHand.material = DefautMaterial;
        LeftHand.material = DefautMaterial;
        RightFoot.material = DefautMaterial;
        LeftFoot.material = DefautMaterial;
        remainingIF -= .075f;
        Invoke("PiscarOn", (5 / remainingIF) * Time.fixedDeltaTime);
    }
    void ChangeToDefaultColor()
    {
        Head.color = new Color(1, 1, 1, 1);
        RightHand.color = new Color(1, 1, 1, 1);
        LeftHand.color = new Color(1, 1, 1, 1);
        RightFoot.color = new Color(1, 1, 1, 1);
        LeftFoot.color = new Color(1, 1, 1, 1);
    }
    void ChangeAlphaPlayer()
    {
        Head.color = new Color(1, 1, 1, .7f);
        RightHand.color = new Color(1, 1, 1, .7f);
        LeftHand.color = new Color(1, 1, 1, .7f);
        RightFoot.color = new Color(1, 1, 1, .7f);
        LeftFoot.color = new Color(1, 1, 1, .7f);
    }
    public void LoadData(GameData data)
    {
        GameManager.Instance.playerLives.lives = data.lives;
    }

    public void SaveData(ref GameData data)
    {
        data.lives = GameManager.Instance.playerLives.lives;
    }
   */
}