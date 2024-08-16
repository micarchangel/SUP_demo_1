using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject endPanel;

    private void Start()
    {
        endPanel.SetActive(false);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
