using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySack : MonoBehaviour
{
    public int scoreBoost = 100; // Увеличение счета

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Score>().AddScore(scoreBoost); // Увеличиваем счет игрока
            Destroy(gameObject); // Уничтожаем мешок после столкновения
        }
    }
}
