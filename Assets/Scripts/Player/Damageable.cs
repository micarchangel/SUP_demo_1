using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Damageable : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> DamageGot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out var obstacle))
        {
            DamageGot?.Invoke(obstacle.Damage);
            //Debug.Log("touch damage");
        }
    }
}
