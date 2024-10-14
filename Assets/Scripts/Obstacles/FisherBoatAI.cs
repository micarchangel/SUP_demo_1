using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherBoatAI : MonoBehaviour
{
    [SerializeField] private float speed = 5f;  // Скорость движения вперед
    [SerializeField] private float turnSpeed = 3f;  // Скорость поворота
    [SerializeField] private float detectionDistance = 10f;  // Дистанция обнаружения препятствий

    // Лучи на разных уровнях по оси Y
    [SerializeField] private float lowerDetectionHeight = 0.5f;
    [SerializeField] private float upperDetectionHeight = 1.0f;
    [SerializeField] private float lower2DetectionHeight = 0.0f;
    [SerializeField] private float upper2DetectionHeight = 1.5f;
    [SerializeField] private float lower3DetectionHeight = 2.0f;
    [SerializeField] private float upper3DetectionHeight = 0.3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Ограничиваем вращение по X и Z
    }

    void Update()
    {
        AvoidObstacles();
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    // Функция для движения вперед
    private void MoveForward()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);
    }

    // Функция для обнаружения и избежания препятствий
    private void AvoidObstacles()
    {
        RaycastHit hit;

        Vector3[] rayOrigins = {
            transform.position + new Vector3(0, lowerDetectionHeight, 0),
            transform.position + new Vector3(0, upperDetectionHeight, 0),
            transform.position + new Vector3(0, lower2DetectionHeight, 0),
            transform.position + new Vector3(0, upper2DetectionHeight, 0),
            transform.position + new Vector3(0, lower3DetectionHeight, 0),
            transform.position + new Vector3(0, upper3DetectionHeight, 0)
        };

        foreach (Vector3 rayOrigin in rayOrigins)
        {
            // Пускаем лучи и проверяем столкновение с необходимыми объектами
            if (Physics.Raycast(rayOrigin, transform.forward, out hit, detectionDistance))
            {
                // Проверка тегов объектов
                if (hit.collider.CompareTag("Ship") || hit.collider.CompareTag("JetSki") ||
                    hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
                {
                    // Слегка поворачиваем, если обнаружен один из объектов
                    float turnDirection = Random.Range(0, 2) == 0 ? -1 : 1;
                    transform.Rotate(0, turnDirection * turnSpeed * Time.deltaTime, 0);
                }
            }
        }
    }

    // Визуализация лучей в редакторе для отладки
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + new Vector3(0, lowerDetectionHeight, 0), transform.forward * detectionDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, upperDetectionHeight, 0), transform.forward * detectionDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + new Vector3(0, lower2DetectionHeight, 0), transform.forward * detectionDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, upper2DetectionHeight, 0), transform.forward * detectionDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + new Vector3(0, lower3DetectionHeight, 0), transform.forward * detectionDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, upper3DetectionHeight, 0), transform.forward * detectionDistance);
    }
}
