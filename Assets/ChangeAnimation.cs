using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAmimantion;
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera camera;
    CameraZoomOut scriptZoomOut;
    public GameObject preBossMusic;

    private void Start()
    {
        scriptZoomOut = GetComponent<CameraZoomOut>();
        scriptZoomOut.enabled = false;
        camera.m_Lens.FieldOfView = 40;
        player.SetActive(false);
        playerAmimantion.SetBool("IsScene1", false);
        playerAmimantion.SetBool("IsScene2", true);
        Invoke("ChangeToGameplay", 7f);
        Invoke("ZoomOut", 6.5f);

    }

    void ChangeToGameplay()
    {
        playerAmimantion.gameObject.SetActive(false);
        player.SetActive(true);
        preBossMusic.SetActive(true);
    }
    void ZoomOut()
    {
        scriptZoomOut.enabled = true;
    }
}
