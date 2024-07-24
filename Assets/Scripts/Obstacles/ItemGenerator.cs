using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] itemsToGenerate; // Массив с префабами объектов для генерации
    public int numberOfItems = 100; // Количество объектов для генерации
    public float minDistanceBetweenItems = 10.0f; // Минимальное расстояние между объектами

    private float waterWidth = 93.44813f;
    private float waterLength = 766.1378f;
    private float waterPosX = 0.293f;
    private float waterPosZ = -449.75f;
    private List<Vector3> generatedPositions = new List<Vector3>(); // Список позиций сгенерированных объектов

    void Start()
    {
        GenerateItems();
    }

    void GenerateItems()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            GenerateRandomItem();
        }
    }

    void GenerateRandomItem()
    {
        if (itemsToGenerate.Length > 0)
        {
            // Выбираем случайный объект из массива
            int randomIndex = Random.Range(0, itemsToGenerate.Length);
            GameObject selectedItem = itemsToGenerate[randomIndex];

            Vector3 randomPosition;
            bool positionIsValid = false;

            // Генерируем случайную позицию в пределах реки
            do
            {
                randomPosition = new Vector3(
                    Random.Range(waterPosX - waterWidth / 2, waterPosX + waterWidth / 2), // Ширина реки
                    12.5f, // Высота (на уровне воды)
                    Random.Range(waterPosZ - waterLength / 2, waterPosZ + waterLength / 2) // Длина реки
                );

                positionIsValid = true;
                // Проверяем, что новая позиция находится на достаточном расстоянии от всех ранее сгенерированных позиций
                foreach (Vector3 pos in generatedPositions)
                {
                    if (Vector3.Distance(randomPosition, pos) < minDistanceBetweenItems)
                    {
                        positionIsValid = false;
                        break;
                    }
                }
            } while (!positionIsValid);

            // Сохраняем позицию нового объекта
            generatedPositions.Add(randomPosition);

            // Создаем выбранный объект в случайной позиции
            Instantiate(selectedItem, randomPosition, Quaternion.identity);
        }
    }
}
