using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAndJetSkiGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] shipsAndJetSkis; // Массив префабов кораблей и гидроциклов

    [SerializeField] private float spawnInterval = 5.0f;     // Интервал между генерацией
    [SerializeField] private float waterWidth = 30.0f;         // Примерная ширина реки
    [SerializeField] private float waterLengthStart = 28.93f;  // Начальная позиция по Z
    [SerializeField] private float waterLengthEnd = -750.0f;   // Конечная позиция по Z
    [SerializeField] private float waterPosX = 0.0f;           // Позиция центра реки по X

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
            int randomIndex = Random.Range(0, shipsAndJetSkis.Length);
            GameObject selectedObject = shipsAndJetSkis[randomIndex];

            Vector3 randomPosition = new Vector3(
                Random.Range(waterPosX - waterWidth / 2, waterPosX + waterWidth / 2), // X – в пределах реки
                transform.position.y,                                                  // Y – на уровне воды
                Random.Range(waterLengthStart, waterLengthEnd)                         // Z – вдоль реки
            );

            GameObject newShip = Instantiate(selectedObject, randomPosition, Quaternion.identity, transform);

            // Применяем раскраску в зависимости от типа объекта
            ApplyShipColor(newShip);
        }
    }

    void ApplyShipColor(GameObject ship)
    {
        // Если объект (или его дочерние) содержит "kazanka" или материал "kazanka_top", используем специальную логику
        if (IsKazankaType(ship))
        {
            ApplyKazankaTopColor(ship);
            return;
        }
        
        // Иначе – стандартная логика для остальных кораблей/гидроциклов:
        // Если меш содержит "corpus" или "yamaha 1", красим их в случайный цвет
        Renderer[] renderers = ship.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            string meshName = rend.gameObject.name.ToLower();
            if (meshName.Contains("corpus"))
            {
                rend.material = new Material(rend.material);
                rend.material.color = GetRandomColor();
            }
            else if (meshName.Contains("yamaha 1"))
            {
                rend.material = new Material(rend.material);
                rend.material.color = GetRandomColor();
            }
            Debug.Log($"[DEBUG] Found mesh: {rend.gameObject.name}", rend.gameObject);
        }
    }

    /// <summary>
    /// Проверяет, относится ли объект к типу Kazanka (например, если его иерархия или материалы содержат "kazanka")
    /// </summary>
    bool IsKazankaType(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            if (rend.material != null)
            {
                string matName = rend.material.name.ToLower();
                string goName = rend.gameObject.name.ToLower();
                if (matName.Contains("kazanka_top") || goName.Contains("kazanka"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Применяет единый случайный цвет ко всем частям объекта, которые принадлежат Kazanka_top.
    /// </summary>
    void ApplyKazankaTopColor(GameObject ship)
    {
        // Выбираем один случайный цвет для всех частей
        Color uniformColor = GetRandomColor();

        Renderer[] renderers = ship.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            string rendererName = rend.gameObject.name.ToLower();
            string materialName = rend.material != null ? rend.material.name.ToLower() : "";
            // Если имя объекта содержит "kazanka" или материал содержит "kazanka_top", окрашиваем его
            if (rendererName.Contains("kazanka") || materialName.Contains("kazanka_top"))
            {
                rend.material = new Material(rend.material);
                rend.material.color = uniformColor;
            }
            Debug.Log($"[DEBUG] Kazanka renderer: {rend.gameObject.name}", rend.gameObject);
        }
    }

    /// <summary>
    /// Возвращает случайный цвет с заданными диапазонами Hue, Saturation и Value.
    /// </summary>
    Color GetRandomColor()
    {
        return Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.7f, 1f);
    }
}
