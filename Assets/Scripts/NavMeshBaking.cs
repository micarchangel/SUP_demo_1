using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshBaking : MonoBehaviour
{
    NavMeshSurface surface;
    [SerializeField] private float delay = 1;

    void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        Invoke("Bake", delay);  
    }

    private void Bake()
    {
        surface.BuildNavMesh();
    }
}
