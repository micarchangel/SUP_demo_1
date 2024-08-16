using UnityEngine;
using UnityEngine.Events;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent End;
    //[SerializeField] private GameObject ending;
    //private EndPanel _endPanel;

    private void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Level Finished!");
            EndGame.Success = true;
            End?.Invoke();
        }
    }
}
