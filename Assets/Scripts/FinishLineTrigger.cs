using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ending;
    private EndPanel _endPanel;

    private void Start()
    {
        _endPanel = ending.GetComponent<EndPanel>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Level Finished!");
            _endPanel.EndGame();
        }
    }
}
