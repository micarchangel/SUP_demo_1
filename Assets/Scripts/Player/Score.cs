using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] UnityEvent<int> scoreChanged;
    [SerializeField] UnityEvent<string> scoreChangedString;
    private int _currentScore;

    public int score
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            scoreChanged?.Invoke(_currentScore);
            scoreChangedString?.Invoke("—чет: " + _currentScore.ToString());
            Debug.Log("Score added");
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        score = 0;
    }

    public void AddScore(float n)
    {
        score += Convert.ToInt32(n);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out var obstacle))
        {
            score += obstacle.Score;
            //Debug.Log("touch score");
        }
    }
}
