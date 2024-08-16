using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject successPanel;
    [SerializeField] private AudioSource inGameAudio;
    [SerializeField] private GameObject playerAudio;
    [SerializeField] private GameObject environmentAudio;
    [SerializeField] private AudioSource riverSound;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text endScore;
    [SerializeField] private float delay = 3.0f;

    static private bool _success;
    static public bool Success
    {
        get => _success;
        set => _success = value;
    }

    public void GameFail()
    {
        StopAudio();
        failPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameComplete()
    {
        endText.text += "\n\n" + endScore.text;
        StopAudio();
        successPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void StopAudio()
    {
        inGameAudio.Stop();
        playerAudio.SetActive(false);
        environmentAudio.SetActive(false);
        riverSound.Stop();
    }

    public void PlayerDeath()
    {
        Debug.Log("END");
        string callFunc;

        if (_success)
        {
            callFunc = "GameComplete";
            delay = 0f;
        }
        else
        {
            callFunc = "GameFail";
        }

        Invoke(callFunc, delay);
    }
}

