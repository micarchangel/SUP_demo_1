using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRiverKater : MonoBehaviour
{
    [SerializeField] private float acceleration = 50.0f; // Ускорение
    [SerializeField] private float maxSpeed = 5f;

    private Rigidbody rb;
    private Transform rbTransform;
    private Vector3 direction;

    private void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();

        rb = GetComponent<Rigidbody>();
        rbTransform = rb.GetComponent<Transform>();
        rb.maxLinearVelocity = maxSpeed;
        //rb.drag = 1f;
    }

    void FixedUpdate()
    {
        // Двигаем кораблик вперед по направлению его курса
        //transform.position += transform.forward * speed * Time.deltaTime;
        direction = rbTransform.TransformDirection(Vector3.forward);
        rb.AddForce(direction * acceleration, ForceMode.Acceleration);
        //Debug.Log(rb.velocity.magnitude);
    }
}

