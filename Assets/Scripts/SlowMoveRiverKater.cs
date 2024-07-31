using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoveRiverKater : MonoBehaviour
{
    public float speed = 0.5f; // Скорость движения

    void Update()
    {
        // Двигаем кораблик вперед по направлению его курса
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

