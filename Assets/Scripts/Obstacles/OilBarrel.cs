using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OilBarrel : MonoBehaviour
{
    public float damageAmount = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.GetDamage(damageAmount); // Наносит ущерб игроку
            }
        }
    }
}
