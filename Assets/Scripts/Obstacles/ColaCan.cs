using UnityEngine;

public class ColaCan : MonoBehaviour
{
    public float staminaBoost = 20f; // Увеличение запаса сил

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Stamina>().AddStamina(staminaBoost); // Увеличиваем запас сил игрока
            Destroy(gameObject); // Уничтожаем банку после столкновения
        }
    }
}
