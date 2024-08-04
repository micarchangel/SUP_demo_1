using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyer : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float destroyDistanceBehind = 1.0f;

  private void Start()
  {
    mainCamera = Camera.main;
  }
    private void Update()
    { 
        //Debug.Log(transform.position.z + " _ " + camera.transform.position.z);
        if (mainCamera != null && transform.position.z > mainCamera.transform.position.z + destroyDistanceBehind)
        {
            Destroy(gameObject);
        }
    }
}
