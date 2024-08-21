using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float sinkingSpeed = 2.0f;
    [SerializeField] private float sinkDuration = 3.0f; // ������������ ����������

    public IEnumerator sinkCoroutine;

    public void PlayerSink()
    {
        //Debug.Log("����������");
        sinkCoroutine = Sink(player);
        StartCoroutine(sinkCoroutine);
    }

    private IEnumerator Sink(GameObject player)
    {
        float elapsedTime = 0.0f;
        Vector3 originalPosition = player.transform.position;
        while (elapsedTime < sinkDuration) // ��������� ������
        {
            player.transform.position = originalPosition - Vector3.up * sinkingSpeed * elapsedTime; // ��������� ������� ������ �� ��� Y
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
