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

    private CapsuleCollider objCollider;
    private float maxY;
    private float minY;
    private Vector3 direction; // Текущее направление движения
    private Vector3 rotation; // Угол поворота бутылки

    void Start()
    {
        if (TryGetComponent<CapsuleCollider>(out objCollider) && objCollider.direction == 1)
        {
            maxY = transform.position.y;
            minY = transform.position.y - objCollider.height / 2 - sinkingValue;
        }
        else
        {
            maxY = transform.position.y - sinkingValue;
            minY = transform.position.y - sinkingValue * 2;
        }

        //Debug.Log($"{name}: maxY = {maxY}; miny = {minY}");

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
        else if (transform.position.y <= minY)
            direction.y = sinkingValue;
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
