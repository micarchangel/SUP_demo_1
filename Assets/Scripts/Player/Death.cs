using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private float delay = 3.0f;
    
    public void GameFail()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerDeath()
    {
        Debug.Log("DIE");
        Invoke("GameFail", delay);
    }
}
