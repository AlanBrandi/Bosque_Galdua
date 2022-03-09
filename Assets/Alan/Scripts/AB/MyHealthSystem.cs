using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public Material HitMaterial;
    public Material DefautMaterial;

    public UiManager ui;
    public GameData_SO GameData;
    public GameObject playerManager;
    public SpriteRenderer Player;
    public Animator ani;
    public float Time_frame = 1;
    public bool PlayerTomouDano = false;

    public SpriteRenderer Head;
    public SpriteRenderer Right_hand;
    public SpriteRenderer Left_hand;
    public SpriteRenderer Right_foot;
    public SpriteRenderer Sword;
    public SpriteRenderer Left_foot;

    bool Blink = false;

    GameObject Hit;
    Animator HitAnim;
    private void Start()
    {
        Hit = GameObject.Find("HitHUD");
        HitAnim = Hit.GetComponent<Animator>();
        Hit.SetActive(false);
    }
    private void Update()
    {
        if (GameData.lives <= 0)
        {
            Die();
        }
        if (Blink == true)
        {
            Invoke("PiscarOn",0);
        }
        else
        {
            TomouDanofalso();
        }
    }

    public void Dano(int dano)
    {
        if(PlayerTomouDano == true)
        {
            Invoke("TomouDanofalso", Time_frame);
        }
        else if (PlayerTomouDano == false)
        {
            GameData.lives -= dano;
            ui.SetLife(GameData.lives);
            Hit.SetActive(true);
            HitAnim.SetTrigger("PlayerHit");
            PlayerTomouDano = true;
            Blink = true;

            //---------FICAR TRANSPARENTE-------------
            
            Head.color = new Color(1, 1, 1, .7f);
            Right_hand.color = new Color(1, 1, 1, .7f);
            Left_hand.color = new Color(1, 1, 1, .7f);
            Right_foot.color = new Color(1, 1, 1, .7f);
            Left_foot.color = new Color(1, 1, 1, .7f);
            Sword.color = new Color(1, 1, 1, .7f);
       
            Invoke(nameof(DisableHit), 1);
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
        Destroy(this.gameObject);
        ui.SetLife(0);
    }

    void TomouDanofalso()
    {
        
        Head.color = new Color(1, 1, 1, 1);
        Right_hand.color = new Color(1, 1, 1, 1);
        Left_hand.color = new Color(1, 1, 1, 1);
        Right_foot.color = new Color(1, 1, 1, 1);
        Left_foot.color = new Color(1, 1, 1, 1);
        Sword.color = new Color(1, 1, 1, 1);
        
        //-----------------------------------
        
        Head.material = DefautMaterial;
        Right_hand.material = DefautMaterial;
        Left_hand.material = DefautMaterial;
        Right_foot.material = DefautMaterial;
        Left_foot.material = DefautMaterial;
        Sword.material = DefautMaterial;

        //-----------------------------
        Blink = false;
        PlayerTomouDano = false;
    }
    void DisableHit()
    {
        Hit.SetActive(false);
    }

    void PiscarOn()
    {
        if(Blink == false)
        {
            Head.color = new Color(1, 1, 1, 1);
            Right_hand.color = new Color(1, 1, 1, 1);
            Left_hand.color = new Color(1, 1, 1, 1);
            Right_foot.color = new Color(1, 1, 1, 1);
            Left_foot.color = new Color(1, 1, 1, 1);
            Sword.color = new Color(1, 1, 1, 1);

            //-----------------------------------

            Head.material = DefautMaterial;
            Right_hand.material = DefautMaterial;
            Left_hand.material = DefautMaterial;
            Right_foot.material = DefautMaterial;
            Left_foot.material = DefautMaterial;
            Sword.material = DefautMaterial;

            //-----------------------------
        }
        else
        {
            Head.material = HitMaterial;
            Right_hand.material = HitMaterial;
            Left_hand.material = HitMaterial;
            Right_foot.material = HitMaterial;
            Left_foot.material = HitMaterial;
            Sword.material = HitMaterial;
            Invoke("PiscarOff", 0.1f);
        }
    }
    void PiscarOff()
    {
        Head.material = DefautMaterial;
        Right_hand.material = DefautMaterial;
        Left_hand.material = DefautMaterial;
        Right_foot.material = DefautMaterial;
        Left_foot.material = DefautMaterial;
        Sword.material = DefautMaterial;
        Invoke("PiscarOn", 0.1f);
    }

}