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
            parentObject = transform.parent; // ������������� �������� ��������, ���� �� �� �����
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (parentObject != null)
        {
            // ������� �������� ��� ������������
            Vector3 collisionForce = collision.relativeVelocity;
            parentObject.position += collisionForce * Time.deltaTime; // ������ �������� ��������
        }
    }
}
