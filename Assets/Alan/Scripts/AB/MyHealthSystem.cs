using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public UiManager ui;
    public int life = 15;
    public GameObject playerManager;
    public Animator ani;

    private void Update()
    {
        if (life <= 0)
        {
            Die();
        }
    }

    public void Dano(int dano)
    {
        life = life - dano;
        ui.SetLife(life);
        return;
    }

    private void Die()
    {
        playerManager.GetComponent<Moving>().enabled = false;
        playerManager.GetComponent<PlayerAttack>().enabled = false;
        playerManager.GetComponent<PlayerHighAttack>().enabled = false;
        playerManager.GetComponent<Jumping>().enabled = false;
        ani.SetFloat("Speed", 0);
        ui.SetLife(0);
    }
}