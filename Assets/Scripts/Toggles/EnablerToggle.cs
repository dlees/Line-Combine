using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablerToggle : Toggle
{
    public MonoBehaviour animator;

    private bool previousValue = false;

    void Start()
    {
        animator.enabled = false;
    }

    public override void toggle(bool value)
    {
        animator.enabled = value;
    }

}
