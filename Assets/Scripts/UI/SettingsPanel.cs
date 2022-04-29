using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public Slider[] slider = new Slider[3];
    private void Start()
    {
        slider[0].value = PlayerPrefs.GetFloat("MasterVol", 1);
        slider[1].value = PlayerPrefs.GetFloat("MusicVol", 1);
        slider[2].value = PlayerPrefs.GetFloat("SFXVol", 1);
    }
}
