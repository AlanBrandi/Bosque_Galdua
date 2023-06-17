using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObjectByEvent : MonoBehaviour
{
   [SerializeField] private GameObject go;

   public void DisableGameObject()
   {
      go.SetActive(false);
   }

   public void EnableGameObject()
   {
      go.SetActive(true);
   }
}
