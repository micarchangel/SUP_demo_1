using System.Collections;
using UnityEngine;

public class ColaCan : MonoBehaviour
{
    [SerializeField] private float staminaBoost = 20f; // Увеличение запаса сил

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Stamina>().AddStamina(staminaBoost); // Увеличиваем запас сил игрока
            other.GetComponent<EnvironmentAudioController>().ColaCan(); // Звук открытия банки
            Destroy(gameObject); // Уничтожаем банку после столкновения
        }
    }
}
