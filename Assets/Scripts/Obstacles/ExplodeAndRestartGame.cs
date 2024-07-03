using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeAndRestartGame : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
