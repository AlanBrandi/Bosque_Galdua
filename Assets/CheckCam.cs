using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckCam : MonoBehaviour
{
    public GameObject boss;

    private void Start()
    {
        boss.active = false;
    }
    public int targetCamera;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !CamManager.INSTANCE.lstCam[targetCamera].isActiveAndEnabled)
        {
            CamManager.INSTANCE.ChangeCam(targetCamera);
            boss.active = true;
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
