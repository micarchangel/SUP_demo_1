using System.Collections;
using UnityEngine;

public class ColaCan : MonoBehaviour
{
    [SerializeField] private GameObject canMesh; // меш бутылки
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float staminaBoost = 20f; // Увеличение запаса сил
    [SerializeField] private float delay = 2.0f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Stamina>().AddStamina(staminaBoost); // Увеличиваем запас сил игрока
            audioSource.Play();
            StartCoroutine(DestroyCoroutine(canMesh, delay));
            //Destroy(gameObject); // Уничтожаем банку после столкновения
        }
    }

    private IEnumerator DestroyCoroutine(GameObject can, float delay)
    {
        can?.SetActive(false);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // Уничтожаем банку после столкновения
    }
}
