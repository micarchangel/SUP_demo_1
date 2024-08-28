using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public Transform player;
    public float destroyDistanceBehind = 20.0f;

    void Update()
    {
        if (player != null && transform.position.z > transform.position.z + destroyDistanceBehind)
        {
            //Debug.Log($"Объект уничтожен.");
            Destroy(gameObject);
        }
    }
}
