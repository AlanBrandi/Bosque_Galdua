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
            DesligarColis�o();
        }
        else
        {
            HealtySystem.PlayerTomouDano = false;
        }
    }

    void DesligarColis�o()
    {
        Physics.IgnoreLayerCollision(0, 12, true);
        Invoke("LigarColis�o", Time);
    }
    void LigarColis�o()
    {
        Physics.IgnoreLayerCollision(0, 12, false);
        HealtySystem.PlayerTomouDano = false;
    }
}
