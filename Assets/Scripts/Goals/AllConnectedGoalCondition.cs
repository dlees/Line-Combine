using UnityEngine;
using System.Collections;

public class AllConnectedGoalCondition : GoalCondition
{
    public ConnectedState connectedState;
    public Board board;
    
    public override string getGoalMessage() 
    {
        return "Connect all Squares together";
    }

    public override bool isConditionSatisfied()
    {
        return connectedState.curConnected.Count == board.maxConnectionsPossible;
    }
}
