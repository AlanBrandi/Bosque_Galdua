using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public UiManager ui;
    public GameData_SO GameData;
    public GameObject playerManager;
    public Animator ani;
    private void Update()
    {
        if (GameData.lives <= 0)
        {
            Die();
        }
    }

    public void Dano(int dano)
    {
        GameData.lives = GameData.lives - dano;
        ui.SetLife(GameData.lives);
        return;
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
}