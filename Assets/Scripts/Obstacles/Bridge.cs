using System.Collections;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float damage = 20f;
    public float sinkDuration = 2.0f; // Время утопления-всплытия
    public float floatHeight = 1.0f; // Высота всплытия

    private Vector3 originalPosition;
    private bool isSinking = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().GetDamage(damage);

            if (!isSinking)
            {
                StartCoroutine(SinkAndRise());
            }
        }
    }

    IEnumerator SinkAndRise()
    {
        isSinking = true;
        Vector3 sinkPosition = new Vector3(originalPosition.x, originalPosition.y - floatHeight, originalPosition.z);

        float elapsedTime = 0;

        while (elapsedTime < sinkDuration / 2)
        {
            transform.position = Vector3.Lerp(originalPosition, sinkPosition, (elapsedTime / (sinkDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(sinkDuration / 2);

        elapsedTime = 0;
        while (elapsedTime < sinkDuration / 2)
        {
            transform.position = Vector3.Lerp(sinkPosition, originalPosition, (elapsedTime / (sinkDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isSinking = false;
    }
}