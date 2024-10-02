using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform endPoint;

    public Vector3 GetPlatformPosition()
    {
        return endPoint.position;
    }
}
