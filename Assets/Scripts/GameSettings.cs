using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class GameSettings : MonoBehaviour
{
    
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private int qualityValue;
    [SerializeField] private float audioVolume;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer am;
    [SerializeField] private int VolCoeff;

    void Start()
    {
        am.SetFloat("masterVolume", Mathf.Log10(audioVolume) * VolCoeff);
        QualitySettings.SetQualityLevel(qualityValue);

        if (slider != null)
        {
            // Привязка функции к изменению значения слайдера
            slider.onValueChanged.AddListener(AudioVolume);
        }

        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(Quality);
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
        Debug.Log("saved audio" + audioVolume);
    }

    public void SaveDropdownValue()
    {
        PlayerPrefs.SetInt("DropdownValue", dropdown.value);
        Debug.Log("saved quality" + audioVolume);
    }

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
        qualityValue = PlayerPrefs.GetInt("DropdownValue");
        slider.value = audioVolume;
        dropdown.value = qualityValue;
        Debug.Log("Loaded audio" + audioVolume);
        Debug.Log("Loaded quality" + qualityValue);
    }

    void OnDisable()
    {
        SaveSliderValue();
        SaveDropdownValue();
    }

    // Управление громкостью слайдером
    void AudioVolume (float sliderValue) {
        am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * VolCoeff);
        audioVolume = sliderValue;
    }
}
