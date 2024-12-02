using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLineBotTrigger : MonoBehaviour
{
    private int _counter;
    public int Counter {
        get { 
            return _counter;
        }
        set
        {
            _counter = value;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            //Debug.Log("Level Finished!");
            EndGame.Success = true;
            _counter++;
        }
    }
}
