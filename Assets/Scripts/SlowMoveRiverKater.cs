using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoveRiverKater : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f; // Скорость движения

    private void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        // Двигаем кораблик вперед по направлению его курса
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

