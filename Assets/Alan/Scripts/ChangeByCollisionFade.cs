using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeByCollisionFade : MonoBehaviour
{
   [SerializeField] private LevelChanger levelChanger;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player"))
      {
         Debug.Log("Entrei uai");
         levelChanger.FadeToLevel("PlayerFallCutscene");
      }
   }
}
