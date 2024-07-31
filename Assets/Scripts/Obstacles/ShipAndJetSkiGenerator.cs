using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAndJetSkiGenerator : MonoBehaviour
{
    public GameObject[] shipsAndJetSkis; // Массив с префабами корабликов и гидроциклов
    public float spawnInterval = 5.0f; // Интервал между генерацией

    private float waterWidth = 30.0f; // Примерная ширина реки
    private float waterLengthStart = 28.93f; // Начальная позиция по Z
    private float waterLengthEnd = -750.0f; // Конечная позиция по Z
    private float waterPosX = 0.0f; // Позиция центра реки по X
    public Transform player;
    public float destroyDistanceBehind = 20.0f; // Расстояние позади игрока, после которого лодки уничтожаются

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
                Random.Range(waterLengthStart, waterLengthEnd) // Длина реки
            );

            GameObject newShip = Instantiate(selectedObject, randomPosition, Quaternion.identity);
            var destroyer = newShip.AddComponent<ObjectDestroyer>();
            destroyer.player = player;
            destroyer.destroyDistanceBehind = destroyDistanceBehind;
        }
    }
}
