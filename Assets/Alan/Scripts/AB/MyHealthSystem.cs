using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public UiManager ui;
    public GameData_SO GameData;
    public GameObject playerManager;
    public SpriteRenderer Player;
    public Animator ani;
    public float Time_frame = 1;
    public bool PlayerTomouDano = false;

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
            Invoke(nameof(DisableHit), 1);
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

        PlayerTomouDano = false;
    }
    void DisableHit()
    {
        Hit.SetActive(false);
    }
}