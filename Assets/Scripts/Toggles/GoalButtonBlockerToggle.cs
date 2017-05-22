using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalButtonBlockerToggle : Toggle
{
    public Button nextLevelButton;

    public override void toggle(bool value)
    {
        nextLevelButton.interactable = value;
    }
}
