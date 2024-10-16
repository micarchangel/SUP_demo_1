using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldRowBoat : MonoBehaviour
{
    [SerializeField] private float speed = 1f;  // Медленная скорость
    [SerializeField] private float turnSpeed = 2f;  // Плавный поворот
    [SerializeField] private float detectionDistance = 5f;  // Дистанция обнаружения

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;  // Ограничить вращение по X и Z
    }

    void Update()
    {
        DetectAndTurn();
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    // Движение вперед
    private void MoveForward()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);
    }

    // Обнаружение препятствий и поворот
    private void DetectAndTurn()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            if (hit.collider.CompareTag("Ship") || hit.collider.CompareTag("JetSki") || hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
            {
                // Плавный поворот в сторону
                float turnDirection = Random.Range(0, 2) == 0 ? -1 : 1;
                transform.Rotate(0, turnDirection * turnSpeed * Time.deltaTime, 0);
            }
        }
    }
}
