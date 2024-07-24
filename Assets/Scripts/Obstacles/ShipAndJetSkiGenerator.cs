using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAndJetSkiGenerator : MonoBehaviour
{
    public GameObject[] shipsAndJetSkis; // Массив с префабами корабликов и гидроциклов
    public float spawnInterval = 5.0f; // Интервал между генерацией

    private float waterWidth = 93.44813f;
    private float waterLength = 766.1378f;
    private float waterPosX = 0.293f;
    private float waterPosZ = -449.75f;

    void Start()
    {
        StartCoroutine(SpawnShipsAndJetSkis());
    }

    IEnumerator SpawnShipsAndJetSkis()
    {
        while (true)
        {
            GenerateRandomShipOrJetSki();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void GenerateRandomShipOrJetSki()
    {
        if (shipsAndJetSkis.Length > 0)
        {
            // Выбор случайного объекта из массива
            int randomIndex = Random.Range(0, shipsAndJetSkis.Length);
            GameObject selectedObject = shipsAndJetSkis[randomIndex];

            // Генерация объекта в случайной позиции в водном пространстве
            Vector3 randomPosition = new Vector3(
                Random.Range(waterPosX - waterWidth / 2, waterPosX + waterWidth / 2), // Ширина реки
                12.5f, // Высота (на уровне воды)
                Random.Range(waterPosZ - waterLength / 2, waterPosZ + waterLength / 2) // Длина реки
            );

            Instantiate(selectedObject, randomPosition, Quaternion.identity);
        }
    }
}
