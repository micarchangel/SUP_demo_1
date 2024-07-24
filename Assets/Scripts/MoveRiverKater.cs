using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRiverKater : MonoBehaviour
{
    public float speed = 2.0f; // Скорость движения

    void Update()
    {
        // Двигаем кораблик вперед по направлению его курса
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

