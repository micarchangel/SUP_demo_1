using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimation : MonoBehaviour
{
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject veslo;
    private Animator animator;
    private ChangeParentVeslo animatorVeslo;
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    private float h;
    private float v;

    void Start()
    {
        lastRotation = GetComponentInParent<Transform>().rotation;
        lastPosition = GetComponentInParent<Transform>().position;
        animator = playerModel.GetComponent<Animator>();
        animatorVeslo = veslo.GetComponent<ChangeParentVeslo>();
    }

    void Update()
    {
        h = Mathf.Sign(lastRotation.y - GetComponentInParent<Transform>().rotation.y);
        v = Mathf.Sign(lastPosition.z - GetComponentInParent<Transform>().position.z);

        Debug.Log($"{h} {v}");

        animator.SetFloat("verticalMove", v);
        animator.SetFloat("horizontalMove", v);

        if (h != 0 || v != 0)
        {
            //animator.SetBool("SwimForward", true);
            //animator.SetBool("SwimBackward", false);
            animator.SetBool("isMove", true);

        }
        else
        {
            animator.SetBool("isMove", false);
            //animator.SetBool("SwimForward", false);
            //animator.SetBool("SwimBackward", true);

        }


        //if (h > 0.01f)
        //    animatorVeslo.ChangeParentObject(0);
        //else if (h < -0.01f)
        //    animatorVeslo.ChangeParentObject(1);
        //else animatorVeslo.ChangeParentObject(0);

        lastPosition = GetComponentInParent<Transform>().position;
        lastRotation = GetComponentInParent<Transform>().rotation;

    }
}
