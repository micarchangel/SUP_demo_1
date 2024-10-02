using System.Collections.Generic;
using UnityEngine;

public class PlatformContainer : MonoBehaviour
{
    public static PlatformContainer instance;
    public WorldBuilder worldBuilder;

    private void Awake()
    {
        if (PlatformContainer.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PlatformContainer.instance = this;
    }

    private void OnDestroy()
    {
        PlatformContainer.instance = null;
    }

    /// <summary>
    /// Формируем список из всех дочерних объектов Контейнера
    /// </summary>
    /// <param name="parent"> Контейнер </param>
    /// <returns></returns>
    private List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
        }

        return children;
    }
}
