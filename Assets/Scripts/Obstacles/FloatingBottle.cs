using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBottle : MonoBehaviour
{
    [SerializeField] private float floatingSpeed = 0.3f; // �������� �������� �������
    [SerializeField] private float rotationSpeed = 1f; // �������� ������� �������
    [SerializeField] private float changeDirectionTime = 2.0f; // ����� �� ����� �����������
    [SerializeField] private float maxSpacing = 1f;
    [SerializeField] private float maxDegree = 30f;
    [SerializeField] private float sinkingValue = 1f; // ��������, �� ������� ������������ �������

    private float maxY;
    private Vector3 direction; // ������� ����������� ��������
    private Vector3 rotation; // ���� �������� �������

    void Start()
    {
        maxY = transform.position.y - sinkingValue;
        // ������ ��������� ��������� �����������
        ChangeDirection();
        ChangeRotation();
        // �������� ������ ����������� ����� ������������ ��������� �������
        InvokeRepeating("ChangeDirection", changeDirectionTime, changeDirectionTime);
        InvokeRepeating("ChangeRotation", changeDirectionTime, changeDirectionTime);
    }

    void Update()
    {
        // ���� ������� �� �������� �� ���� ��-�� ��������
        if (transform.position.y >= maxY)
            direction.y = -sinkingValue;
        else
            transform.Rotate(rotationSpeed * Time.deltaTime * rotation, Space.Self);

        transform.Translate(floatingSpeed * Time.deltaTime * direction);
    }

    void ChangeDirection()
    {
        // ���������� ��������� �����������
        direction = new Vector3(Random.Range(-maxSpacing, maxSpacing), 0, Random.Range(-maxSpacing, maxSpacing)).normalized;
    }

    void ChangeRotation()
    {
        rotation = new Vector3(Random.Range(-maxDegree, maxDegree), 0, Random.Range(-maxDegree, maxDegree)).normalized;
    }
}
