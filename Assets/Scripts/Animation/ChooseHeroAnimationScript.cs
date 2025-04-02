using UnityEngine;

public class ChooseHeroAnimationScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("ChooseInt", 1);
    }

    public void PressHeroButton()
    {
        animator.SetInteger("ChooseInt", 1);
    }

    public void PressSupBoardButton()
    {
        animator.SetInteger("ChooseInt", 2);
    }
}
