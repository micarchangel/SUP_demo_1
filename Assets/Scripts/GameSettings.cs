using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;
    [SerializeField] private AudioMixer am;
    [SerializeField] private int VolCoeff = 30;
    [SerializeField] private Slider audioVolume;

    private void Update()
    {
        audioVolume = GetComponent<Slider>();
        float lvl;
        am.GetFloat("masterVolume", out lvl);
        lvl = Mathf.Pow(10, lvl / VolCoeff);
        Debug.Log(lvl);
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * VolCoeff);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
