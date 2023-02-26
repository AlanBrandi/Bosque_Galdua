using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAmimantion;
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera camera;

    private void Start()
    {
       // camera.m_Lens.FieldOfView = 50;
        player.SetActive(false);
        playerAmimantion.SetBool("IsScene1", false);
        playerAmimantion.SetBool("IsScene2", true);
        Invoke("ChangeToGameplay", 8);
    }

    void ChangeToGameplay()
    {
        playerAmimantion.gameObject.SetActive(false);
        player.SetActive(true);
       // camera.m_Lens.FieldOfView = 60;
    }
}
