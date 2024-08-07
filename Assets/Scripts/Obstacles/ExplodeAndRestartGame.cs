using UnityEngine;

public class ExplodeAndRestartGame : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private AudioClip explosionSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Взрыв");
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
