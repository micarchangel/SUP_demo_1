using UnityEngine;
using System.Collections;

public class SpeedBoostBottle : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 2.0f; // Коэффициент увеличения скорости
    [SerializeField] private float boostDuration = 5.0f;   // Длительность ускорения

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<EnvironmentAudioController>().BoosterBottle();
            StartCoroutine(BoostSpeed(other.gameObject));
        }
    }

    IEnumerator BoostSpeed(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.velocity = rb.velocity * speedMultiplier;
            Destroy(gameObject); // Удаляем бутылку после столкновения
            yield return new WaitForSeconds(boostDuration);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(BoostSpeed(gameObject));
    }
}
