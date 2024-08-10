using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float sinkDuration = 2.0f; // Время утопления/всплытия
    public float floatHeight = 2.0f; // Высота всплытия
    public float floatInterval = 2.0f; // Интервал между утоплением и всплытием

    private Vector3 originalPosition;
    private bool isSinking = false;

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(SinkAndRiseRoutine());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Уничтожить рыбу при столкновении с игроком
        }
    }

    IEnumerator SinkAndRiseRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(floatInterval);
            yield return SinkAndRise();
        }
    }

    IEnumerator SinkAndRise()
    {
        isSinking = true;
        Vector3 sinkPosition = new Vector3(originalPosition.x, originalPosition.y - floatHeight, originalPosition.z);

        float elapsedTime = 0;

        while (elapsedTime < sinkDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, sinkPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(floatInterval);

        elapsedTime = 0;
        while (elapsedTime < sinkDuration)
        {
            transform.position = Vector3.Lerp(sinkPosition, originalPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isSinking = false;
    }
}

