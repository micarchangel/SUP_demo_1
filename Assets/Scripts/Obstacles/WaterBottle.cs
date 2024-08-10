using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterBottle : MonoBehaviour
{
    public float staminaBoost = 20f; // Увеличение запаса сил

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Stamina>().AddStamina(staminaBoost); // Увеличиваем запас сил игрока
            Destroy(gameObject); // Уничтожаем бутылку после столкновения
        }
    }
}
