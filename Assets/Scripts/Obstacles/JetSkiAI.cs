using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetSkiAI : MonoBehaviour
{
    [SerializeField] private float speed = 1f;  // Скорость движения вперед
    [SerializeField] private float turnSpeed = 5f;  // Скорость поворота
    [SerializeField] private float detectionDistance = 5f;  // Дистанция обнаружения препятствий

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
        rb.AddForce(transform.forward * speed, ForceMode.Force);  // Добавляем силу для движения вперед
    }

    // Функция для обхода препятствий
    private void AvoidObstacles()
    {
        RaycastHit hit;

        // Если обнаружено препятствие впереди, поворачиваем
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            // Поворачиваем в случайную сторону, если впереди препятствие
            float turnDirection = Random.Range(0, 2) == 0 ? -1 : 1;  // Случайно выбираем направление поворота
            transform.Rotate(0, turnDirection * turnSpeed * Time.deltaTime, 0);
        }
    }
}
