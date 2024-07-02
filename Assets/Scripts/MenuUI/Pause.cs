using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public AudioMixer am;
    public int VolCoeff = 30;
    

    public void Start()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void Update()
    {
        if (panel.activeSelf)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PersController>().EscapeMenu = true;
        }
        else if (!panel.activeSelf)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PersController>().EscapeMenu = false;
        }
    }

    public void MyPause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MyPlay() { 
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void toMainMenu() {
        SceneManager.LoadScene("Menu");
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
