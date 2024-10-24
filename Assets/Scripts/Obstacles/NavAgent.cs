using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    //[SerializeField] private Vector3 XYZ;
    [SerializeField] private Transform wayPoint;

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(wayPoint.position);
    }
}
