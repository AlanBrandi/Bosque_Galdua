using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeUISelected : MonoBehaviour
{
  [Header("GameObjects")]
  [SerializeField] private GameObject go1;
  [SerializeField] private GameObject go2;
  
  [Header("EventSystem")]
  [SerializeField] private EventSystem eventSystem;

  
  public void SelectFirst()
  {
    eventSystem.firstSelectedGameObject = go1;
    eventSystem.SetSelectedGameObject(go1);
  }
  public void SelectSecond()
  {
    eventSystem.firstSelectedGameObject = go2;
    eventSystem.SetSelectedGameObject(go2);
  }

  public void ChangeSelectedToThis(GameObject newSelection)
  {
    eventSystem.SetSelectedGameObject(newSelection);
  }
}
