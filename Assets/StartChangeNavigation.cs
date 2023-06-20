using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class StartChangeNavigation : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject go1;

    private void Start()
    {
        eventSystem.firstSelectedGameObject = go1;
        eventSystem.SetSelectedGameObject(go1);
    }
}
