using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PressSettingsButton()
    {
        animator.SetInteger("menu", 1);
    }
    public void PressSettingsBackButton()
    {
        animator.SetInteger("menu", 0);
    }

    public void PressAboutButton()
    {
        animator.SetInteger("menu", 2);
    }

    public void PressAboutBackButton()
    {
        animator.SetInteger("menu", 0);
    }


    public void PressSoundButton()
    {
        animator.SetInteger("menu", 3);
    }

    public void PressSoundBackButton()
    {
        animator.SetInteger("menu", 1);
    }

}
