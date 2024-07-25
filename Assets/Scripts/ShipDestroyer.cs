using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyer : MonoBehaviour
{
    public Transform player;
    public float destroyDistanceBehind = 20.0f;

    void Update()
    {
        if (player != null && transform.position.z < player.position.z - destroyDistanceBehind)
        {
            Destroy(gameObject);
        }
    }
}
