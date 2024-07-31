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
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text endScore;

    private void Start()
    {
        endPanel.SetActive(false);

    }

    public void EndGame()
    {
        endText.text += "\n\n" + endScore.text;
        inGamePanel.SetActive(false);
        endPanel.SetActive(true);
        Time.timeScale = 0f;
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
