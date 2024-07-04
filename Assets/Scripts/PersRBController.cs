using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Transform))]
public class PersRBController : MonoBehaviour
{

    [SerializeField] private float turnSpeed = 0.1f;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float drag = 1f;

    private Transform supTransform;
    private Vector3 direction;
    private Quaternion supRotation;    
    private Rigidbody rb;
    private float h;
    private float v;

    private void Start()
    {
        rb= GetComponent<Rigidbody>();
        supTransform= rb.GetComponent<Transform>();
        rb.drag = drag;
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = supTransform.TransformDirection(Vector3.forward);
    }

    private void FixedUpdate()
    {
        playerMovement();
        Debug.Log(rb.velocity + "_____" + v + "____" + direction);
    }

    private void playerMovement()
    {
        supRotation = Quaternion.Euler(Vector3.up * h * turnSpeed);
        rb.MoveRotation(rb.rotation * supRotation);
        rb.AddForce(direction*speed*-v, ForceMode.Force);


    }

}
