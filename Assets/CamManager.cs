using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{
    public static CamManager INSTANCE;
    public List<CinemachineVirtualCamera> lstCam = new List<CinemachineVirtualCamera>();
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeCam(int camNumber)
    {
            DisableAllCams();
            lstCam[camNumber].gameObject.SetActive(true);
    }
    private void DisableAllCams()
    {
        foreach (CinemachineVirtualCamera camTmp in lstCam)
        {
            camTmp.gameObject.SetActive(false);
        }
    }
}
