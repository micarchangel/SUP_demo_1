using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public int VolCoeff = 30;

    public void Start()
    {
        //QualitySettings.SetQualityLevel(3);
    }    

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    //public void AudioVolume(float sliderValue) {
    //    am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * VolCoeff);
    //}

    //public void Quality(int q)
    //{
    //    QualitySettings.SetQualityLevel(q);
    //}
}
