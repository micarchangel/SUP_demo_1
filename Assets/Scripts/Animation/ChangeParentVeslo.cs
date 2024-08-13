using UnityEngine;

public class ChangeParentVeslo : MonoBehaviour
{
    [SerializeField] private GameObject[] parentObjects;
    private Transform currentParent;
    private int parentIndex;

    void Start()
    {
        currentParent = transform.parent;
        parentIndex = 0;
        ChangeParentObject(parentIndex);
    }

    public void ChangeParentObject(int parentIndex)
    {
        GameObject newParent = parentObjects[parentIndex];

        transform.SetParent(newParent.transform, true);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        currentParent = newParent.transform;
    }
}
