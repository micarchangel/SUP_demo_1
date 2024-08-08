using UnityEngine;
using System.Collections;

public class SpeedBoostBottle : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 2.0f; // Коэффициент увеличения скорости
    [SerializeField] private float boostDuration = 5.0f;   // Длительность ускорения
    [SerializeField] private float delay = 2.0f;
    [SerializeField] private GameObject bottle;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            StartCoroutine(BoostSpeed(other.gameObject, delay));
        }
    }

    IEnumerator BoostSpeed(GameObject player, float delay)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.velocity = rb.velocity * speedMultiplier;
            bottle.SetActive(false);
            yield return new WaitForSeconds(delay);
            Destroy(gameObject); // Удаляем бутылку после столкновения
            yield return new WaitForSeconds(boostDuration);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(BoostSpeed(gameObject, delay));
    }
}
