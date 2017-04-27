using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggle : Toggle
{
    public MonoBehaviour animator;

    private bool previousValue = false;

    void Start()
    {
        animator.enabled = false;
    }

    public override void toggle(bool value)
    {
        if (value && !previousValue)
        {
            previousValue = value;
                animator.enabled = true;
        }
        else if (!value && previousValue)
        {
            previousValue = value;
                animator.enabled = false;
        }

    }

}
