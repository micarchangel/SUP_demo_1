using UnityEngine;

public class PersController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float moveSpeed = 1f;
    private Vector3 direction;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(-x*speed, 0, -(moveSpeed + z));

        controller.Move(direction * Time.deltaTime);
    }
}
