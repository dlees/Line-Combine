using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposeAllCondition : Condition {
    public Condition[] conditions;
	
    public override bool isConditionSatisfied()
    {
        foreach (Condition condition in conditions)
        {
            if (!condition.isConditionSatisfied())
            {
                return false;
            }
        }
        return true;
    }
}
