using UnityEngine;
using System.Collections;

public class SinkBuoy : MonoBehaviour
{
    public float sinkingSpeed = 2.0f; // Скорость потопления

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("SinkBuoy - OnTriggerEnter triggered with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Sink());
        }
    }

    IEnumerator Sink()
    {
        while (true)
        {
            transform.Translate(Vector3.down * sinkingSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
