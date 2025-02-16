using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] objectsToGenerate; // Массив объектов для генерации

    // Список объектов-бутылок
    private List<string> bottleObjects = new List<string>
    {
        "BoosterBottle", "BoosterBottle2", "waterBottle 1"
    };

    // Список деревянных объектов
    private List<string> woodenObjects = new List<string>
    {
        "wodenCrate", "WoodBox", "WoodBox2", "WoodenBarrel"
    };

    // Пастельная палитра для бутылок (цвета для тела и крышки)
    private List<Color> softColors = new List<Color>
    {
        new Color(0.9f, 0.6f, 0.6f),  // Светло-красный
        new Color(0.6f, 0.8f, 0.6f),  // Пастельно-зеленый
        new Color(0.6f, 0.7f, 0.9f),  // Светло-синий
        new Color(0.9f, 0.9f, 0.6f),  // Пастельно-желтый
        new Color(1.0f, 0.7f, 0.5f),  // Лососевый
        new Color(0.7f, 0.5f, 1.0f),  // Лавандовый
        new Color(0.7f, 1.0f, 0.9f),  // Аквамарин
        new Color(1.0f, 0.6f, 0.8f),  // Светло-розовый
        new Color(0.7f, 0.9f, 0.5f),  // Светло-зеленый
        new Color(0.8f, 0.8f, 0.8f),  // Светло-серый
        new Color(0.9f, 0.5f, 0.3f),  // Терракотовый
        new Color(0.6f, 0.4f, 0.2f),  // Карамельный
        new Color(0.8f, 0.9f, 0.7f),  // Лаймовый пастельный
        new Color(0.5f, 0.5f, 0.9f),  // Светлый индиго
        new Color(0.9f, 0.7f, 0.5f),  // Песочный
        new Color(0.6f, 0.9f, 0.8f),  // Бирюзовый пастельный
        new Color(0.8f, 0.6f, 0.9f),  // Сиреневый
        new Color(0.9f, 0.8f, 0.6f),  // Бежевый
        new Color(0.7f, 0.3f, 0.3f),  // Гранатовый
        new Color(0.6f, 0.3f, 0.1f),  // Охра
        new Color(0.8f, 0.5f, 0.7f),  // Розово-лиловый
        new Color(0.5f, 0.8f, 0.6f),  // Светлая мята
        new Color(0.9f, 0.6f, 0.7f),  // Персиковый пастельный
        new Color(0.5f, 0.9f, 0.9f),  // Нежно-голубой
        new Color(0.7f, 0.5f, 0.4f),  // Кофейный
        new Color(0.4f, 0.6f, 0.9f),  // Голубой синий
        new Color(0.8f, 0.8f, 0.5f),  // Золотисто-желтый
        new Color(0.7f, 0.9f, 0.9f),  // Нежный лазурный
        new Color(0.9f, 0.7f, 0.9f),  // Светлый фиолетовый
        new Color(0.8f, 0.4f, 0.3f)   // Темно-терракотовый
    };

    void Start()
    {
        GenerateRandomObject();
    }

    void GenerateRandomObject()
    {
        if (objectsToGenerate.Length > 0)
        {
            int randomIndex = Random.Range(0, objectsToGenerate.Length);
            GameObject selectedObject = objectsToGenerate[randomIndex];

            GameObject newObject = Instantiate(selectedObject, transform.position, transform.rotation, transform);

            ApplyColorChange(newObject);
        }
    }

    void ApplyColorChange(GameObject obj)
    {
        // Убираем "(Clone)" из имени
        string objName = obj.name.Replace("(Clone)", "").Trim();

        if (bottleObjects.Contains(objName))
        {
            ApplyBottleColor(obj);
        }
        else if (woodenObjects.Contains(objName))
        {
            ApplyWoodColor(obj);
        }
    }

    void ApplyBottleColor(GameObject obj)
    {
        // Выбираем случайный цвет для корпуса бутылки
        Color bodyColor = softColors[Random.Range(0, softColors.Count)];
        // Выбираем цвет для крышки, не совпадающий с телом
        Color capColor;
        do
        {
            capColor = softColors[Random.Range(0, softColors.Count)];
        }
        while (capColor == bodyColor);

        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            string meshName = rend.gameObject.name.ToLower();
            if (meshName.Contains("capbottle"))
            {
                rend.material.color = capColor;
            }
            else if (meshName.Contains("bodybottle"))
            {
                rend.material.color = bodyColor;
            }
            Debug.Log($"[DEBUG] Bottle renderer found: {rend.gameObject.name}", rend.gameObject);
        }
    }

    void ApplyWoodColor(GameObject obj)
    {
        // Генерируем случайный множитель яркости в диапазоне [0.7, 1.3]
        float brightness = Random.Range(0.7f, 1.3f);
        Color brightnessTint = new Color(brightness, brightness, brightness, 1f);

        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            // Создаем копию материала, чтобы не менять общий материал
            rend.material = new Material(rend.material);
            // Вместо полного изменения цвета, умножаем текущий цвет на brightnessTint.
            // Если исходный цвет материала белый (1,1,1), то результат — чистое затемнение или осветление.
            rend.material.color *= brightnessTint;
            Debug.Log($"[DEBUG] Wood renderer: {rend.gameObject.name}, brightness factor: {brightness}", rend.gameObject);
        }
    }
}
