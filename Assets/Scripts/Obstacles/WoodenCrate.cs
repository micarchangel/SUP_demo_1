using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : MonoBehaviour
{
    public GameObject objectToGenerate;
    public float generationDistance = 1.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GenerateObject();
        }
    }

    void GenerateObject()
    {
        Vector3 generationPosition = transform.position + (transform.forward * generationDistance);
        Instantiate(objectToGenerate, generationPosition, Quaternion.identity);
    }
}
