using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    GameObject PlayerGO;
    GameObject playerManager;
    public float Time_frame = 1;
    float remainingIF;
    public bool PlayerTomouDano = false;

    public SpriteRenderer Head;
    public SpriteRenderer Right_hand;
    public SpriteRenderer Left_hand;
    public SpriteRenderer Right_foot;
    public SpriteRenderer Sword;
    public SpriteRenderer Left_foot;

    bool Blink = false;

    GameObject Hit;
    Animator hitAnim;
    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        Hit = GameObject.Find("HitHUD");
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
            Right_hand.color = new Color(1, 1, 1, .7f);
            Left_hand.color = new Color(1, 1, 1, .7f);
            Right_foot.color = new Color(1, 1, 1, .7f);
            Left_foot.color = new Color(1, 1, 1, .7f);
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
        Destroy(gameObject);
        GameManager.Instance.DecreaseLife(0);
    }
    void TomouDanofalso()
    {

        Head.color = new Color(1, 1, 1, 1);
        Right_hand.color = new Color(1, 1, 1, 1);
        Left_hand.color = new Color(1, 1, 1, 1);
        Right_foot.color = new Color(1, 1, 1, 1);
        Left_foot.color = new Color(1, 1, 1, 1);
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
            Right_hand.color = new Color(1, 1, 1, 1);
            Left_hand.color = new Color(1, 1, 1, 1);
            Right_foot.color = new Color(1, 1, 1, 1);
            Left_foot.color = new Color(1, 1, 1, 1);
            Sword.color = new Color(1, 1, 1, 1);
        }
        else
        {
            // Cor
            /*Head.material = HitMaterial;
            Right_hand.material = HitMaterial;
            Left_hand.material = HitMaterial;
            Right_foot.material = HitMaterial;
            Left_foot.material = HitMaterial;
            Sword.material = HitMaterial;*/
            //Transparente
            Head.color = new Color(1, 1, 1, .3f);
            Right_hand.color = new Color(1, 1, 1, .3f);
            Left_hand.color = new Color(1, 1, 1, .3f);
            Right_foot.color = new Color(1, 1, 1, .3f);
            Left_foot.color = new Color(1, 1, 1, .3f);
            Sword.color = new Color(1, 1, 1, .3f);
            remainingIF -= .075f;
            Invoke("PiscarOff", (5/remainingIF) * Time.fixedDeltaTime);
        }
    }
    void PiscarOff()
    {
        //Cor
        /*Head.material = DefautMaterial;
        Right_hand.material = DefautMaterial;
        Left_hand.material = DefautMaterial;
        Right_foot.material = DefautMaterial;
        Left_foot.material = DefautMaterial;
        Sword.material = DefautMaterial;*/

        //Transparente
        Head.color = new Color(1, 1, 1, 1);
        Right_hand.color = new Color(1, 1, 1, 1);
        Left_hand.color = new Color(1, 1, 1, 1);
        Right_foot.color = new Color(1, 1, 1, 1);
        Left_foot.color = new Color(1, 1, 1, 1);
        Sword.color = new Color(1, 1, 1, 1);

        remainingIF -= .075f;
        Invoke("PiscarOn", (5/remainingIF) * Time.fixedDeltaTime);
    }
}