using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject chooseCharacterMenu;
    private void Start()
    {
        chooseCharacterMenu.SetActive(false);
    }
    public void PlayPressed()
    {
        //SceneManager.LoadScene("1stLevel");
        //Time.timeScale = 1f;
        mainMenu.SetActive(false);
        chooseCharacterMenu.SetActive(true);
    }

    public void StartPressed()
    {
        SceneManager.LoadScene("1stLevel");
        Time.timeScale = 1f;
    }

    public void BackPressed()
    {
        mainMenu.SetActive(true);
        chooseCharacterMenu.SetActive(false);
    }

    public void ExitPressed() { 
        Application.Quit();
        Debug.Log("Method ExitPressed has worked!");
    }
}
