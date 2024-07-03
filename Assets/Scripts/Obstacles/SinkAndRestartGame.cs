using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SinkAndRestartGame : MonoBehaviour
{
    public float sinkingSpeed = 2.0f; // Скорость потопления

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("SinkAndRestartGame - OnTriggerEnter triggered with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SinkAndRestart(other.gameObject));
        }
    }

    IEnumerator SinkAndRestart(GameObject player)
    {
        float elapsedTime = 0.0f;
        Vector3 originalPosition = player.transform.position;
        while (elapsedTime < 3.0f) // Погружаем игрока за 3 секунды
        {
            player.transform.position = originalPosition - Vector3.up * sinkingSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Перезагружаем текущую сцену
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
