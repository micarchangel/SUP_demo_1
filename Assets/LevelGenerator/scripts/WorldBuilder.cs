using UnityEngine;


public class WorldBuilder : MonoBehaviour
{
    public GameObject[] freePlatforms; // массив платформ без припятствий 
    public Transform platformContainer; // родительский объект в котором создаются платформы

    private Transform lastPlatform = null; // переменная для хранения позиции последней платформы

    void Start()
    {
        Init();
    }

    /// <summary>
    /// Создание платформ
    /// </summary>
    public void CreatePlatform()
    {
        Vector3 pos = (lastPlatform == null) ? // если платформы нет, то координаты pos равны координатам контейнера, если есть, то координаты равны конечной точке последней платформы.
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().GetPlatformPosition();
        int index = Random.Range(0, freePlatforms.Length);
        GameObject res = Instantiate(freePlatforms[index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
    }

    /// <summary>
    /// Появление платформ на старте
    /// </summary>
    public void Init()
    {
        for (int i = 0; i < 8; i++)
        {
            CreatePlatform();
        }
    }

}
