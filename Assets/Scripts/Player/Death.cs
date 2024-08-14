using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private float delay = 3.0f;
    [SerializeField] private AudioSource inGameAudio;
    [SerializeField] private GameObject playerAudio;
    [SerializeField] private GameObject environmentAudio;
    
    public void GameFail()
    {
        inGameAudio.Stop();
        playerAudio.SetActive(false);
        environmentAudio.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerDeath()
    {
        Debug.Log("DIE");
        Invoke("GameFail", delay);
    }
}
