using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public Boss boss;
    public GameObject bossGo;
    public GameObject Musicboss;
    public GameObject preBossMusic;

    public GameObject healthBar;
    public bool canTakeDamageInicial;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            
            healthBar.SetActive(true);
                boss.canStart = true;
                Musicboss.SetActive(true);
            preBossMusic.SetActive(false);
                bossGo.SetActive(true);
            this.gameObject.SetActive(false);
            Destroy(this);
            
        }
    }
}
