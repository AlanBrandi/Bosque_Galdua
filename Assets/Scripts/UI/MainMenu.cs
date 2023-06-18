using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class MainMenu : MonoBehaviour
{
    [Header("SettingsPanel")]
    [SerializeField] private GameObject settingsPanel;
    
    [Header("FirstSelected")]
    [SerializeField] private GameObject go1;
    [SerializeField] private GameObject go2;
    
    [Header("InputSystem")]
    [SerializeField] private InputSystemUIInputModule inputModule;
    
    private void Update()
    {
        if (settingsPanel.activeInHierarchy)
        {
            if (inputModule.cancel.action.triggered)
            {
                ToggleSettings();
            }
        }
    }

    public void ToggleSettings()
    {
        if (settingsPanel.activeInHierarchy == false)
        {
            settingsPanel.SetActive(true);
            inputModule.gameObject.GetComponent<EventSystem>().SetSelectedGameObject(go2);
        }
        else
        {
            settingsPanel.GetComponent<Animator>().SetTrigger("ExitSettings");
            inputModule.gameObject.GetComponent<EventSystem>().SetSelectedGameObject(go1);
        }
    }
}
