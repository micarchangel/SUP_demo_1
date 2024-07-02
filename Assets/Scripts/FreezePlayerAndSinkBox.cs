using UnityEngine;
using System.Collections;

public class FreezePlayerBox : MonoBehaviour
{
    public float freezeDuration = 3.0f; // Длительность остановки

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FreezePlayer(other.gameObject));
        }
    }

    IEnumerator FreezePlayer(GameObject player)
    {
        PersController controller = player.GetComponent<PersController>();
        if (controller != null)
        {
            float originalSpeed = controller.moveSpeed; // Запоминаем исходную скорость вперед/назад
            controller.moveSpeed = 0; // Останавливаем движение
            yield return new WaitForSeconds(freezeDuration); // Ждем, пока игрок остановлен
            controller.moveSpeed = originalSpeed; // Восстанавливаем исходную скорость
        }
        Destroy(gameObject); // Удаляем ящик после столкновения
    }
}
