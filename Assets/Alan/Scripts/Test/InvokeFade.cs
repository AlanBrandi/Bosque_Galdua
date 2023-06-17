using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeFade : MonoBehaviour
{
  [SerializeField] private LevelChanger levelChanger;
  [SerializeField] private AudioSource mainMusic;

  private float delayTime = 3.4f;
  private string levelName;
  
  public void CallFade(string level)
  {
    levelName = level;
    Invoke(nameof(StartFade), 0f);
    StartCoroutine(ChangeMusicVolume());
  }
  private IEnumerator ChangeMusicVolume()
  {
    float targetVolume = 0f;
    float volumeChangeSpeed = 0.99f;

    while (mainMusic.volume > 0)
    {
      mainMusic.volume = Mathf.Lerp(mainMusic.volume, targetVolume, volumeChangeSpeed * Time.deltaTime);
      yield return null;
    }
    mainMusic.volume = targetVolume;
  }
  private void StartFade()
  {
    levelChanger.FadeToLevel(levelName);
  }
}
