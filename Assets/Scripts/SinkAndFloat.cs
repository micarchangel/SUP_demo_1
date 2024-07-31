using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkAndFloat : MonoBehaviour
{
    public float sinkDuration = 4.0f; // время утопления-всплытия
    public float floatHeight = 2.0f; // высота всплытия

    private Vector3 originalPosition;
    private bool isSinking = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
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

        while (elapsedTime < sinkDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, sinkPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        elapsedTime = 0;
        while (elapsedTime < sinkDuration)
        {
            transform.position = Vector3.Lerp(sinkPosition, originalPosition, (elapsedTime / sinkDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isSinking = false;
    }
}
