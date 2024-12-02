using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class LeaderBoardPanel : MonoBehaviour
{
    [SerializeField] private float templateHeight = 50f; // Высота строки
    //[SerializeField] private int leadersCount = 20; // Количество записей

    
    [SerializeField] private Transform _content; // Родительский объект
    [SerializeField] private Transform _row; // Дочерний объект

    //private List<HighScoreEntry> _highScoreEntryList;
    private List<Transform> _highScoreEntryTransformList; // Записи таблицы
    private int _countOfChilds;


    private void Awake()
    {
        //_content = transform.Find("Viewport");
        //_row = _content.Find("Content");

        _countOfChilds = _content.childCount;
        _row.gameObject.SetActive(false);

        //PlayerPrefs.DeleteKey("highScoreTable");

        if (!PlayerPrefs.HasKey("highScoreTable"))
        {
            HighScoreEntry emptyField = new HighScoreEntry();
            string json = JsonUtility.ToJson(emptyField);
            PlayerPrefs.SetString("highScoreTable", json);
            PlayerPrefs.Save();
            Debug.Log("Запись добавлена");
        }

        //GetHighscore();
    }

    public void GetHighscore()
    {
        // Выгружаем данные
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Удаляем созданные строки, чтобы не дублировалось
        while (_content.childCount > _countOfChilds)
        {
            Transform child = _content.Find("Row(Clone)");
            //Debug.Log($"Объект {child.name} удален");
            DestroyImmediate(child.gameObject);
        }

        // Сортировка
        IEnumerable<HighScoreEntry> orderedScoreList;
        orderedScoreList = highscores.highscoreEntryList.OrderByDescending(x => x.score).ThenBy(x => x.time);

        // Заполняем таблицу
        _highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in orderedScoreList)
            CreateHighScoreEntryTransform(highScoreEntry, _content, _highScoreEntryTransformList);
    }

    // Отрисовка и заполнение строки таблицы
    private void CreateHighScoreEntryTransform(HighScoreEntry highScore, Transform container, List<Transform> transformList)
    {
        // Рисуем таблицу
        Transform entryTransform = Instantiate(_row, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        // Заполняем поля
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

    // Добавление рекорда
    public void AddHighscoreEntry(string name, int score, float time)
    {
        //Создаем объект
        HighScoreEntry highscoreEntry = new() { name = name, score = score, time = time };

        // Загружаем сохраненные данные
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Добавляем в список
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Сохраняем в PlayerPrefs
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();

        //GetHighscore();

        Debug.Log("Записано " + name + ' ' + score + ' ' +time);
    }

    // Список рекордов
    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    // Класс для рекорда
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
        public float time;
    }
}
