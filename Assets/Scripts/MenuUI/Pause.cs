using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button pauseUIButton;
    [SerializeField] private AudioMixer am;
    [SerializeField] private int VolCoeff = 30;
    private bool escapeMenu;

    private void Start()
    {
        escapeMenu = false;
        pausePanel.gameObject.SetActive(false);
        QualitySettings.SetQualityLevel(3);
    }

    private void Update()
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
        Time.timeScale = 0f;
    }

    public void MyPlay() { 
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ToMainMenu() {
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
