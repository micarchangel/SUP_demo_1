using System.Collections;
using UnityEngine;

public class Tina : MonoBehaviour
{
    //[SerializeField] private float slowDownDuration = 5.0f; // Продолжительность замедления игрока в секундах
    [SerializeField] private float speedCoeff = 0.2f; // коэфф. скорости игрока
    [SerializeField] private float sinkDuration = 4.0f; // время утопления-всплытия
    [SerializeField] private float floatHeight = 2.0f; // высота всплытия
    [SerializeField] private float floatDelay = 2.0f; // время задержки перед всплытием тины

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Начинаем замедление игрока
            PersRBController playerController = other.GetComponent<PersRBController>();
            if (playerController != null)
            {
                playerController.Speed *= speedCoeff; // Замедляем скорость на 80% (оставляем 20% от исходной)
            }
        }
        else if (other.CompareTag("Ship") || other.CompareTag("JetSki"))
        {
            // Код для потопления и всплытия
            StartCoroutine(SinkAndFloat(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Восстанавливаем скорость игрока при выходе из тины
            PersRBController playerController = other.GetComponent<PersRBController>();
            if (playerController != null)
            {
                playerController.Speed /= speedCoeff; // Восстанавливаем скорость до исходной
            }
        }
    }

    private IEnumerator SinkAndFloat(GameObject obj)
    {
        Vector3 originalPosition = obj.transform.position;
        Vector3 sinkPosition = new Vector3(originalPosition.x, originalPosition.y - floatHeight, originalPosition.z);

        float elapsedTime = 0;

        while (elapsedTime < sinkDuration)
        {
            obj.transform.position = Vector3.Lerp(originalPosition, sinkPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(floatDelay);

        elapsedTime = 0;
        while (elapsedTime < sinkDuration)
        {
            obj.transform.position = Vector3.Lerp(sinkPosition, originalPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = originalPosition;
    }
}
