using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCondition : Condition
{
    public Timer timer;

    public override bool isConditionSatisfied()
    {
        return timer.TimeLeft > 0;
    }
}
