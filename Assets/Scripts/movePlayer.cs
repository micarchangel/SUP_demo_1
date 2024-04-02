using UnityEngine;

public class movePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        Debug.Log("MoveLeft");
        rb.AddForce(Vector3.left * speed);
    }
    private void MoveRight()
    {
        Debug.Log("MoveRight");
        rb.AddForce(Vector3.right * speed);
    }

}
