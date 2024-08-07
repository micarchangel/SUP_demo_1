using System.Collections;
using UnityEngine;

public class ExplodeAndRestartGame : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private AudioSource explosionSource;
    [SerializeField] private GameObject seaMineMesh;
    [SerializeField] private float delay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Взрыв");
            explosionSource.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            seaMineMesh.SetActive(false);
            StartCoroutine(delayCouroutine(delay));
        }
    }

    private IEnumerator delayCouroutine(float delay)
    { 
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
