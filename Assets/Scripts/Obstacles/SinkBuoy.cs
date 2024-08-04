using UnityEngine;
using System.Collections;

public class SinkBuoy : MonoBehaviour
{
    [SerializeField] private float sinkingSpeed = 2.0f; // Скорость потопления

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("SinkBuoy - OnTriggerEnter triggered with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Sink());
        }
    }

    private IEnumerator Sink()
    {
        while (true)
        {
            transform.Translate(Vector3.down * sinkingSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
