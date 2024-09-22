using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tina : MonoBehaviour
{
    public float speedCoeff = 0.2f;  // Коэффициент замедления скорости
    public float sinkDuration = 4.0f;  // Время погружения
    public float floatHeight = 2.0f;  // Высота всплытия
    public float floatDelay = 2.0f;  // Задержка перед всплытием

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Начинаем замедление игрока
            PersRBController playerController = other.GetComponent<PersRBController>();
            if (playerController != null)
            {
                StartCoroutine(SlowDownPlayer(playerController));
            }
        }
        else if (other.CompareTag("Ship") || other.CompareTag("JetSki"))
        {
            // Погружаем тину
            StartCoroutine(SinkAndFloat());
        }
    }

    private IEnumerator SlowDownPlayer(PersRBController playerController)
    {
        float originalSpeed = playerController.Speed; // Сохраняем оригинальную скорость
        playerController.Speed *= speedCoeff; // Замедляем скорость игрока

        yield return new WaitForSeconds(3.0f); // Время замедления

        playerController.Speed = originalSpeed; // Восстанавливаем скорость
    }

    private IEnumerator SinkAndFloat()
    {
        Vector3 originalPosition = transform.position;
        Vector3 sinkPosition = new Vector3(originalPosition.x, originalPosition.y - floatHeight, originalPosition.z);

        float elapsedTime = 0;

        // Погружаем объект
        while (elapsedTime < sinkDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, sinkPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(floatDelay); // Задержка перед всплытием

        elapsedTime = 0;
        // Всплытие объекта
        while (elapsedTime < sinkDuration)
        {
            transform.position = Vector3.Lerp(sinkPosition, originalPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition; // Возвращаем тину на исходное место
    }
}
