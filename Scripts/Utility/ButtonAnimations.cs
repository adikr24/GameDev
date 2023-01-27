using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimations : MonoBehaviour
{
    Animator animator;

    public void OnMouseEnter()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isHighlighted", true);
    }

    public void OnMouseExit()
    {
        animator.SetBool("isHighlighted", false);
    }
}
