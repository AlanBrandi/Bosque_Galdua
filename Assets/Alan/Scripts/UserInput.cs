using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    [HideInInspector] public PlayerController playerController;
    [HideInInspector] public Vector2 moveInput;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerController = new PlayerController();
        playerController.InGame.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }
}
