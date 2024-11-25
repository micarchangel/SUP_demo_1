using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionHandler : MonoBehaviour
{
    private Transform parentObject;

    void Start()
    {
        if (parentObject == null)
        {
            parentObject = transform.parent; // ”станавливаем текущего родител€, если он не задан
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (parentObject != null)
        {
            // —мещаем родител€ при столкновении
            Vector3 collisionForce = collision.relativeVelocity;
            parentObject.position += collisionForce * Time.deltaTime; // ѕример простого смещени€
        }
    }
}
