using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckCam : MonoBehaviour
{
    public int targetCamera;
    

    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !CamManager.INSTANCE.lstCam[targetCamera].isActiveAndEnabled)
        {
            CamManager.INSTANCE.ChangeCam(targetCamera);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !CamManager.INSTANCE.lstCam[targetCamera].isActiveAndEnabled)
        {
            CamManager.INSTANCE.ChangeCam(targetCamera);
        }
    }
}
