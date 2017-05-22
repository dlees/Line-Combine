using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnectedCondition : Condition
{
    public CellPipes pipes;

    public override bool isConditionSatisfied()
    {
        return pipes.IsConnected;
    }
}
