using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetSkiAI : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;  // Скорость движения вперед
    [SerializeField] private float turnSpeed = 30f;  // Скорость поворота
    [SerializeField] private float detectionDistanceShipEnemy = 10f;  // Дистанция для Ship и Enemy
    [SerializeField] private float detectionDistanceObstacles = 5f;  // Дистанция для Obstacle
    [SerializeField] private float detectionDistancePlayer = 2f;  // Дистанция для Player
    [SerializeField] private float lowerRayOffset = 0.5f;  // Смещение луча для проверки низких объектов
    [SerializeField] private float maxTurnAngle = 45f; // Максимальный угол поворота для более резких маневров

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Ограничиваем вращение по X и Z
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
        // Гидроцикл продолжает двигаться вперед, даже при повороте
        Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement);
    }

    // Функция для обхода препятствий
    private void AvoidObstacles()
    {
        RaycastHit hitCenter, hitLower;

        // Центр объекта
        Vector3 rayOriginCenter = transform.position;

        // Нижняя точка объекта для обнаружения низких препятствий
        Vector3 rayOriginLower = new Vector3(transform.position.x, transform.position.y - lowerRayOffset, transform.position.z);

        // Проверка для Ship и Enemy
        if (Physics.Raycast(rayOriginCenter, transform.forward, out hitCenter, detectionDistanceShipEnemy) && (hitCenter.collider.CompareTag("Ship") || hitCenter.collider.CompareTag("Enemy")))
        {
            TurnAway();
        }

        // Проверка для Obstacle
        if (Physics.Raycast(rayOriginLower, transform.forward, out hitLower, detectionDistanceObstacles) && hitLower.collider.CompareTag("Obstacles"))
        {
            TurnAway();
        }

        // Проверка для Player
        if (Physics.Raycast(rayOriginCenter, transform.forward, out hitCenter, detectionDistancePlayer) && hitCenter.collider.CompareTag("Player"))
        {
            TurnAway();
        }
    }

    // Функция для изменения направления (поворот на более резкий угол)
    private void TurnAway()
    {
        // Поворачиваем на угол до 45 градусов, чтобы маневры были более заметными
        float turnDirection = Random.Range(0, 2) == 0 ? -1 : 1;  // Случайно выбираем направление поворота
        float turnAngle = turnDirection * turnSpeed * Time.deltaTime;
        transform.Rotate(0, Mathf.Clamp(turnAngle, -maxTurnAngle, maxTurnAngle), 0);
    }

    // Визуализация Raycast для отладки
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistanceShipEnemy);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistanceObstacles);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistancePlayer);
    }
}
