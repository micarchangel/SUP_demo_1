using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject successPanel;
    [SerializeField] private AudioSource inGameAudio;
    [SerializeField] private AudioMixer inGameSoundsAM;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text endScore;
    [SerializeField] private TMP_Text endTime;
    [SerializeField] private TMP_Text playerName; 
    [SerializeField] private float delay = 3.0f;
    

    static private bool _success;
    static public bool Success
    {
        get => _success;
        set => _success = value;
    }

    private void Start()
    {
        inGameSoundsAM.SetFloat("InGameSoundsVolume", 0f);
    }

    public void GameFail()
    {
        GameSettings.IsPlaying = false;
        StopAudio();
        failPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameComplete()
    {
        GameSettings.IsPlaying = false;
        endText.text += "\n" + endScore.text + '\n' + endTime.text;
        StopAudio();
        successPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void StopAudio()
    {
        inGameAudio.Stop();
        inGameSoundsAM.SetFloat("InGameSoundsVolume", -80f);
    }

    public void PlayerDeath()
    {
        Debug.Log("END");
        string callFunc;

        if (_success)
        {
            callFunc = "GameComplete";
            delay = 3f;
        }
        else
        {
            callFunc = "GameFail";
        }

        Invoke(callFunc, delay);
    }
}

