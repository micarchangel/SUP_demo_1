using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float audioVolume;
    [SerializeField] private AudioMixer am;

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SaveSliderValue()
    {
        // Сохраняем значение слайдера в PlayerPrefs
        PlayerPrefs.SetFloat("SliderValue", slider.value);
        Debug.Log("saved " + audioVolume);
    }

    //public void OnSceneChange(Scene scene, LoadSceneMode mode)
    //{
    //    // Сохраняем значение слайдера перед переходом к другой сцене
    //    SaveSliderValue();
    //}

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    void OnEnable()
    {
        audioVolume = PlayerPrefs.GetFloat("SliderValue");
        slider.value = audioVolume;
        Debug.Log("Loaded " + audioVolume);
    }

    void OnDisable()
    {
        SaveSliderValue();
    }
}
