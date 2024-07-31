using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> DamageGot;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Obstacle>(out var obstacle))
        {
            DamageGot?.Invoke(obstacle.Damage);
        }
    }
}
