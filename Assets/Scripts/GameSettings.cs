using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameSettings : MonoBehaviour
{
    
    [SerializeField] private Dropdown qualityValue;
    [SerializeField] private float audioVolume;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer am;
    [SerializeField] private int VolCoeff;

    void Start()
    {
        am.SetFloat("masterVolume", Mathf.Log10(audioVolume) * VolCoeff);

        if (slider != null)
        {
            // Привязка функции к изменению значения слайдера
            slider.onValueChanged.AddListener(AudioVolume);
        }

        //qualityValue.onValueChanged.AddListener(Quality);
    }

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log(Screen.fullScreen);
    }

    public void SaveSliderValue()
    {
        // Сохраняем значение слайдера в PlayerPrefs
        PlayerPrefs.SetFloat("SliderValue", slider.value);
        Debug.Log("saved " + audioVolume);
    }

    //public void SaveDropdownValue()
    //{
    //    PlayerPrefs.SetInt("DropdownValue", qualityValue);
    //}

    //public void OnSceneChange(Scene scene, LoadSceneMode mode)
    //{
    //    // Сохраняем значение слайдера перед переходом к другой сцене
    //    SaveSliderValue();
    //}

    //Управление качеством
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

    // Управление громкостью слайдером
    void AudioVolume (float sliderValue) {
        am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * VolCoeff);
        audioVolume = sliderValue;
    }
}
