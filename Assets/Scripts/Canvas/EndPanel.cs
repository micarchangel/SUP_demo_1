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
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject player;
    [SerializeField] private LeaderBoardPanel leaderBoard;

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

    public void SaveScore()
    {
        string name = nameText.text;
        int score = player.GetComponent<Score>().score;
        float time = player.GetComponent<InGameTime>().PlayerTime;

        leaderBoard.AddHighscoreEntry(name, score, time);
        leaderBoard.GetHighscore();
    }
}
