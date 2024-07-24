using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ShipGeneration : MonoBehaviour
{
    public GameObject[] shipsToGenerate; // Массив типов корабликов для генерации
    public float spawnInterval = 5.0f; // Интервал между генерацией корабликов

    void Start()
    {
        StartCoroutine(SpawnShips());
    }

    IEnumerator SpawnShips()
    {
        while (true)
        {
            GenerateRandomShip();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void GenerateRandomShip()
    {
        if (shipsToGenerate.Length > 0)
        {
            // Выбираем случайный кораблик из массива
            int randomIndex = Random.Range(0, shipsToGenerate.Length);
            GameObject selectedShip = shipsToGenerate[randomIndex];

            // Создаем выбранный кораблик в позиции "ShipGenerationPoint"
            Instantiate(selectedShip, transform.position, transform.rotation);
        }
    }
}
