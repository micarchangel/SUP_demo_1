using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    //[SerializeField] private Vector3 XYZ;
    private Transform wayPoint;
    private NavMeshAgent _agent;

    void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("WayPoint").transform;
        _agent = GetComponent<NavMeshAgent>();
        if(wayPoint != null)
            _agent.SetDestination(wayPoint.position);
        Debug.Log($"{gameObject.name} : Точка назначения = {wayPoint.position}");
    }
}
