using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public UiManager ui;
    public int life = 15;
    public GameObject player;

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
    }

    private void Die()
    {
        player.GetComponent<Moving>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<HighAttack>().enabled = true;
        player.GetComponent<Jumping>().enabled = true;
        //animação de morrer
        ui.SetLife(0);
    }
}