using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibility_frame : MonoBehaviour
{
   float Time = 4;
   public MyHealthSystem HealtySystem;

    private void Update()
    {
        if(HealtySystem.PlayerTomouDano == true)
        {
            DesligarColisão();
        }
        else
        {
            HealtySystem.PlayerTomouDano = false;
        }
    }

    void DesligarColisão()
    {
        Physics.IgnoreLayerCollision(0, 12, true);
        Invoke("LigarColisão", Time);
    }
    void LigarColisão()
    {
        Physics.IgnoreLayerCollision(0, 12, false);
        HealtySystem.PlayerTomouDano = false;
    }
}
