using UnityEngine;

public class PersController : MonoBehaviour
{
    public float speed = 5f;
    public float moveSpeed = 1f;
    Vector3 direction;
    CharacterController controller;




    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(-x*speed, 0, -(moveSpeed + z));

        controller.Move(direction * Time.deltaTime);

    }
}
