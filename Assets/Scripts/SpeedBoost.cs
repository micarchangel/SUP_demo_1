using UnityEngine;
using System.Collections;

public class SpeedBoostBottle : MonoBehaviour
{
    public float speedMultiplier = 2.0f; // Коэффициент увеличения скорости
    public float boostDuration = 5.0f;   // Длительность ускорения

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BoostSpeed(other.gameObject));
        }
    }

    IEnumerator BoostSpeed(GameObject player)
    {
        PersController controller = player.GetComponent<PersController>();
        if (controller != null)
        {
            float originalSpeed = controller.moveSpeed; // Запоминаем исходную скорость вперед/назад
            controller.moveSpeed *= speedMultiplier;    // Увеличиваем только движение вперед/назад
            yield return new WaitForSeconds(boostDuration); // Ожидаем в течение длительности ускорения
            controller.moveSpeed = originalSpeed;       // Восстанавливаем исходную скорость
        }
        Destroy(gameObject); // Удаляем бутылку после столкновения
    }
}
