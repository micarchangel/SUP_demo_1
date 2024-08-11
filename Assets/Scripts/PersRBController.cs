using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Transform))]
public class PersRBController : MonoBehaviour
{

    [SerializeField] private float turnSpeed = 0.1f;
    [SerializeField] private float speed = 15f;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

    public bool IsKeyDown
    {
        get { return isKeyDown; }
        set { isKeyDown = value; }
    }

    [SerializeField] private float drag = 1f;

    private Transform supTransform;
    private Vector3 direction;
    private Quaternion supRotation;    
    private Rigidbody rb;
    private AudioSource audioSource;
    private bool isKeyDown = false;
    private float h;
    private float v;

    private void Start()
    {
        Time.timeScale = 1f;
        rb= GetComponent<Rigidbody>();
        supTransform= rb.GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        rb.drag = drag;
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = supTransform.TransformDirection(Vector3.forward);
        if (v > 0 || h > 0)
        {
            isKeyDown = true;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            isKeyDown = false;
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }

    private void FixedUpdate()
    {
        playerMovement();
        //Debug.Log(rb.velocity + "_____" + v + "____" + direction);
    }

    private void playerMovement()
    {
        supRotation = Quaternion.Euler(Vector3.up * h * turnSpeed);
        rb.MoveRotation(rb.rotation * supRotation);
        rb.AddForce(direction*speed*-v, ForceMode.Force);


    }

}
