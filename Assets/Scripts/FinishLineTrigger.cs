using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Здесь можно добавить эффекты или звуки, если нужно
            Debug.Log("Level Finished!");
            SceneManager.LoadScene(0);
        }
    }
}
