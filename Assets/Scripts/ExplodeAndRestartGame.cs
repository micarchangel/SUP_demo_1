using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExplodeAndRestartGame : MonoBehaviour
{
    public GameObject explosionEffect;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ExplodeAndRestartGame - OnTriggerEnter triggered with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with Player");
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
