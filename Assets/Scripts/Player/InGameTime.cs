using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InGameTime : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> timerText;

    private float _timer;

    void Start()
    {
        Init();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        timerText?.Invoke("Время: " + Mathf.Floor(_timer).ToString());
    }

    private void Init()
    {
        _timer = 0f;
    }
}
