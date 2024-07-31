using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameObject playerModel;
    private Animator animator;

    private float h;
    private float v;

    void Start()
    {
        animator = playerModel.GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        animator.SetFloat("verticalMove", v);
        animator.SetFloat("horizontalMove", h);
    }
}
