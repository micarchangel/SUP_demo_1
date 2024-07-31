using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyer : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float destroyDistanceBehind = 1.0f;

  private void Start()
  {
    camera = Camera.main;
  }
    private void Update()
    { 
        Debug.Log(transform.position.z + " _ " + camera.transform.position.z);
        if (camera != null && transform.position.z > camera.transform.position.z + destroyDistanceBehind)
        {
            Destroy(gameObject);
        }
    }
}
