using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBottle : MonoBehaviour
{
    [SerializeField] private float floatingSpeed = 0.3f; // Скорость движения бутылки
    [SerializeField] private float rotationSpeed = 1f; // Скорость наклона бутылки
    [SerializeField] private float changeDirectionTime = 2.0f; // Время до смены направления
    [SerializeField] private float maxSpacing = 1f;
    [SerializeField] private float maxDegree = 30f;
    [SerializeField] private float sinkingValue = 1f; // значение, на которое притопляется бутылка

    private float maxY;
    private Vector3 direction; // Текущее направление движения
    private Vector3 rotation; // Угол поворота бутылки

    void Start()
    {
        maxY = transform.position.y - sinkingValue;
        // Задаем начальное случайное направление
        ChangeDirection();
        ChangeRotation();
        // Начинаем менять направление через определенные интервалы времени
        InvokeRepeating("ChangeDirection", changeDirectionTime, changeDirectionTime);
        InvokeRepeating("ChangeRotation", changeDirectionTime, changeDirectionTime);
    }

    void Update()
    {
        // Чтоб объекты не вылетали из воды из-за вращения
        if (transform.position.y >= maxY)
            direction.y = -sinkingValue;
        else
            transform.Rotate(rotationSpeed * Time.deltaTime * rotation, Space.Self);

        transform.Translate(floatingSpeed * Time.deltaTime * direction);
    }

    void ChangeDirection()
    {
        // Генерируем случайное направление
        direction = new Vector3(Random.Range(-maxSpacing, maxSpacing), 0, Random.Range(-maxSpacing, maxSpacing)).normalized;
    }

    void ChangeRotation()
    {
        rotation = new Vector3(Random.Range(-maxDegree, maxDegree), 0, Random.Range(-maxDegree, maxDegree)).normalized;
    }
}
