using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] objectsToGenerate; // Массив объектов для генерации

    void Start()
    {
        GenerateRandomObject();
    }

    void GenerateRandomObject()
    {
        if (objectsToGenerate.Length > 0)
        {
            // Выбираем случайный объект из массива
            int randomIndex = Random.Range(0, objectsToGenerate.Length);
            GameObject selectedObject = objectsToGenerate[randomIndex];

            // Создаем выбранный объект в позиции `GenerationPoint`
            Instantiate(selectedObject, transform.position, transform.rotation, transform);
        }
    }
}

