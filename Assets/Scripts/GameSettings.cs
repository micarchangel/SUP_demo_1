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
    [SerializeField] private int videoQuality;

    //private void Awake()
    //{
    //    if (!instance)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(audioVolume);
    //    } else
    //    {
    //        Destroy(audioVolume);
    //    }
    //}

    //private void OnLevelWasLoaded(int level)
    //{
    //    audioVolume = GameObject.FindGameObjectWithTag("AudioSlider").GetComponent<Slider>();
    //    Debug.Log(audioVolume.ToString());
    //}

    private void Update()
    {
        audioVolume = GetComponent<Slider>();
        float lvl;
        am.GetFloat("masterVolume", out lvl);
        lvl = Mathf.Pow(10, lvl / VolCoeff);
        //audioVolume.value = lvl;
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
