using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public string groupName;
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(groupName, 1);
    }
    public void SetLevel(float sliderValue)
    {
        audioMixer.SetFloat(groupName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(groupName, sliderValue);
       // Debug.Log(sliderValue);
    }

}
