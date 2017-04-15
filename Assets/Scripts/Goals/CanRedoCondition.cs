using UnityEngine;
using System.Collections;

public class CanRedoCondition : Condition
{
    public ActionStack stack;

    public override bool isConditionSatisfied()
    {
        return stack.canRedo();
    }
}
