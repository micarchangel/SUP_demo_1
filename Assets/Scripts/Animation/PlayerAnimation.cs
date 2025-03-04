using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //[SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject veslo;
    private Animator animator;
    private ChangeParentVeslo animatorVeslo;

    private float h;
    private float v;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorVeslo = veslo.GetComponent<ChangeParentVeslo>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        animator.SetFloat("verticalMove", v);
        animator.SetFloat("horizontalMove", h);

        if (v != 0 || h !=0)
        {
            animator.SetBool("isMove", true);

        }
        else
        {
            animator.SetBool("isMove", false);
        }


        if (h > 0.1f)
            animatorVeslo.ChangeParentObject(0);
        else if (h < -0.1f)
            animatorVeslo.ChangeParentObject(1);
        else animatorVeslo.ChangeParentObject(0);

    }
}
