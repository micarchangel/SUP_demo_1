using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentBot : MonoBehaviour
{
    private Transform finishPoint;
    private NavMeshAgent _agent;

    void Start()
    {
        finishPoint = GameObject.FindGameObjectWithTag("FinishPoint").transform;
        _agent = GetComponent<NavMeshAgent>();
        if (finishPoint != null)
            _agent.SetDestination(finishPoint.position);
        Debug.Log($"{gameObject.name} : Точка назначения = {finishPoint.position}");
    }
}
