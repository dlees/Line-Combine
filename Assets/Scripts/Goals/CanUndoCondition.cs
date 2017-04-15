using UnityEngine;
using System.Collections;

public class CanUndoCondition : Condition
{
    public ActionStack stack;

    public override bool isConditionSatisfied()
    {
        return stack.canUndo();
    }
}
