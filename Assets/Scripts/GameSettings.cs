using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private TMP_Dropdown dropdown;    
    [SerializeField] private Slider sliderMain;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSound;
    [SerializeField] private AudioMixer mainAM;
    [SerializeField] private AudioMixer musicAM;
    [SerializeField] private AudioMixer soundAM;
    [SerializeField] private int VolCoeff;

    private float mainAudioVolume;
    private float musicAudioVolume;
    private float soundAudioVolume;
    private int qualityValue;

    void Start()
    {
        mainAM.SetFloat("masterVolume", Mathf.Log10(mainAudioVolume) * VolCoeff);
        musicAM.SetFloat("musicVolume", Mathf.Log10(musicAudioVolume) * VolCoeff);
        soundAM.SetFloat("soundVolume", Mathf.Log10(soundAudioVolume) * VolCoeff);
        QualitySettings.SetQualityLevel(qualityValue);

        // Привязка функции к изменению значения слайдера
        sliderMain?.onValueChanged.AddListener(MainAudioVolume);
        sliderMusic?.onValueChanged.AddListener(MusicAudioVolume);
        sliderSound?.onValueChanged.AddListener(SoundAudioVolume);

        dropdown?.onValueChanged.AddListener(Quality);

        //qualityValue.onValueChanged.AddListener(Quality);
    }

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log(Screen.fullScreen);
    }

    public void SoundOnToggle()
    {
        AudioListener.pause = !AudioListener.pause;
        Debug.Log("Звук " + !AudioListener.pause);
    }

    public void SaveSlidersValue()
    {
        // Сохраняем значение слайдеров в PlayerPrefs
        PlayerPrefs.SetFloat("SliderMainValue", sliderMain.value);
        PlayerPrefs.SetFloat("SliderMusicValue", sliderMusic.value);
        PlayerPrefs.SetFloat("SliderSoundValue", sliderSound.value);
        Debug.Log("saved audio " + mainAudioVolume + ' ' + musicAudioVolume + ' ' + soundAudioVolume);
    }

    public void SaveDropdownValue()
    {
        PlayerPrefs.SetInt("DropdownValue", dropdown.value);
        Debug.Log("saved quality" + mainAudioVolume);
    }

    //public void OnSceneChange(Scene scene, LoadSceneMode mode)
    //{
    //    // Сохраняем значение слайдера перед переходом к другой сцене
    //    SaveSliderMainValue();
    //}

    //Управление качеством
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    // Загрузка настроек
    void OnEnable()
    {
        mainAudioVolume = PlayerPrefs.GetFloat("SliderMainValue");
        musicAudioVolume = PlayerPrefs.GetFloat("SliderMusicValue");
        soundAudioVolume = PlayerPrefs.GetFloat("SliderSoundValue");
        qualityValue = PlayerPrefs.GetInt("DropdownValue");
        sliderMain.value = mainAudioVolume;
        sliderMusic.value = musicAudioVolume;
        sliderSound.value = soundAudioVolume;
        dropdown.value = qualityValue;
        Debug.Log("Loaded audio " + mainAudioVolume + ' ' + musicAudioVolume + ' ' + soundAudioVolume);
        Debug.Log("Loaded quality " + qualityValue);
    }

    // Сохранение настроек
    void OnDisable()
    {
        SaveSlidersValue();
        SaveDropdownValue();
    }

    // Управление громкостью слайдерами
    void MainAudioVolume (float sliderValue) {
        mainAM.SetFloat("masterVolume", Mathf.Log10(sliderValue) * VolCoeff);
        mainAudioVolume = sliderValue;
    }

    void MusicAudioVolume(float sliderValue)
    {
        musicAM.SetFloat("musicVolume", Mathf.Log10(sliderValue) * VolCoeff);
        musicAudioVolume = sliderValue;
    }

    void SoundAudioVolume(float sliderValue)
    {
        soundAM.SetFloat("soundVolume", Mathf.Log10(sliderValue) * VolCoeff);
        soundAudioVolume = sliderValue;
    }
}
