using UnityEngine;
using System.Collections;

public class AllConnectedGoalCondition : GoalCondition
{
    public ConnectedState connectedState;
    public Board board;
    
    public override string getGoalMessage() 
    {
        return "Combine all lines together";
    }

    public override bool isGoalSatisfied()
    {
        return connectedState.curConnected.Count == board.maxConnectionsPossible;
    }
}
