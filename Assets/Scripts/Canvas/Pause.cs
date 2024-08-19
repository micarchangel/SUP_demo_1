using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button pauseUIButton;
    [SerializeField] private AudioMixer am;

    private bool escapeMenu;

    public void Start()
    {
        escapeMenu = false;
        pausePanel.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escapeMenu)
            {
                pausePanel.SetActive(true);
                pauseUIButton.gameObject.SetActive(false);
                escapeMenu = true;
                Time.timeScale = 0f;
            }
            else
            {
                pausePanel.SetActive(false);
                pauseUIButton.gameObject.SetActive(true);
                escapeMenu = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void MyPause()
    {
        pausePanel.SetActive(true);
        pauseUIButton.gameObject.SetActive(false);
        escapeMenu = true;
        GameSettings.IsPlaying = false;
        Time.timeScale = 0f;
    }

    public void MyPlay() { 
        pausePanel.SetActive(false);
        pauseUIButton.gameObject.SetActive(true);
        escapeMenu = false;
        GameSettings.IsPlaying = true;
        Time.timeScale = 1f;
    }

    public void toMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    //public void AudioVolume(float sliderValue)
    //{
    //    am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * VolCoeff);
    //}

    //public void Quality(int q)
    //{
    //    QualitySettings.SetQualityLevel(q);
    //}
}
