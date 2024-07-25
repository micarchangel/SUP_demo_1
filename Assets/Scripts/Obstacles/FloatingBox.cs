using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBox : MonoBehaviour
{
    public float speed = 0.3f; // Скорость движения ящика
    public float changeDirectionTime = 2.0f; // Время до смены направления

    private Vector3 direction; // Текущее направление движения

    void Start()
    {
        // Задаем начальное случайное направление
        ChangeDirection();
        // Начинаем менять направление через определенные интервалы времени
        InvokeRepeating("ChangeDirection", changeDirectionTime, changeDirectionTime);
    }

    void Update()
    {
        // Двигаем ящик в текущем направлении
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // Генерируем случайное направление
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Ящик тонет при столкновении с игроком
            StartCoroutine(SinkAndDestroy());
        }
    }

    IEnumerator SinkAndDestroy()
    {
        // Медленно тонем
        while (transform.position.y > -5f)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return null;
        }
        // Уничтожаем ящик после того, как он утонул
        Destroy(gameObject);
    }
}
