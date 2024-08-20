using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardPanel : MonoBehaviour
{
    [SerializeField] private float templateHeight = 50f; // ������ ������
    //[SerializeField] private int leadersCount = 20; // ���������� �������

    private Transform _viewport; // ������������ ������
    private Transform _content; // �������� ������
    //private List<HighScoreEntry> _highScoreEntryList;
    private List<Transform> _highScoreEntryTransformList; // ������ �������
   
    private void Awake()
    {
        _viewport = transform.Find("Viewport");
        _content = _viewport.Find("Content");

        _content.gameObject.SetActive(false);

        //PlayerPrefs.DeleteKey("highScoreTable");

        if (!PlayerPrefs.HasKey("highScoreTable"))
        {
            HighScoreEntry emptyField = new HighScoreEntry();
            string json = JsonUtility.ToJson(emptyField);
            PlayerPrefs.SetString("highScoreTable", json);
            PlayerPrefs.Save();
            Debug.Log("������ ���������");
        }

        //GetHighscore();
    }

    public void GetHighscore()
    {
        // ��������� ������
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // ����������
        IEnumerable<HighScoreEntry> orderedScoreList;
        orderedScoreList = highscores.highscoreEntryList.OrderByDescending(x => x.score).ThenBy(x => x.time);

        // ��������� �������
        _highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in orderedScoreList)
            CreateHighScoreEntryTransform(highScoreEntry, _viewport, _highScoreEntryTransformList);
    }

    // ��������� � ���������� ������ �������
    private void CreateHighScoreEntryTransform(HighScoreEntry highScore, Transform container, List<Transform> transformList)
    {
        // ������ �������
        Transform entryTransform = Instantiate(_content, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        // ��������� ����
        string rank = (transformList.Count + 1).ToString();
        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rank;

        string name = highScore.name;
        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        int score = highScore.score;
        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();

        float time = highScore.time;
        entryTransform.Find("timeText").GetComponent<TMP_Text>().text = time.ToString();

        transformList.Add(entryTransform);
    }

    // ���������� �������
    public void AddHighscoreEntry(string name, int score, float time)
    {
        //������� ������
        HighScoreEntry highscoreEntry = new() { name = name, score = score, time = time };

        // ��������� ����������� ������
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // ��������� � ������
        highscores.highscoreEntryList.Add(highscoreEntry);

        // ��������� � PlayerPrefs
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();

        GetHighscore();

        Debug.Log("�������� " + name + ' ' + score + ' ' +time);
    }

    // ������ ��������
    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    // ����� ��� �������
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
        public float time;
    }
}
