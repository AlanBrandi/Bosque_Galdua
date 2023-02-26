using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckCam : MonoBehaviour
{
    public int targetCamera;
    public Boss boss;
    public GameObject bossGo;

    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !CamManager.INSTANCE.lstCam[targetCamera].isActiveAndEnabled)
        {
            CamManager.INSTANCE.ChangeCam(targetCamera);
            if (targetCamera == 1)
            {
                boss.canStart = true;
                bossGo.SetActive(true);
            }
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
