using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("1stLevel");
        Time.timeScale = 1f;
    }

    public void ExitPressed() { 
        Application.Quit();
        Debug.Log("Method ExitPressed has worked!");
    }
}
