using System.Collections;
using UnityEngine;

public class ExplodeAndRestartGame : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Взрыв");
            other.GetComponent<EnvironmentAudioController>().SeaMine();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
