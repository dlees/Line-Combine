using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConnectStartToPointsCondition : GoalCondition
{
    public List<Vector2> thisGoalPoints;
    public string goalString;
    public ConnectedState connectedState;
    public Board board;

    public ConnectStartToPointsCondition(List<Vector2> goal, string goalMessage, ConnectedState connectedState, Board board)
    {
        thisGoalPoints = goal;
        goalString = goalMessage;
        this.connectedState = connectedState;
        this.board = board;
    }

    public override string getGoalMessage() 
    {
        return goalString;
    }

    public override bool isGoalSatisfied()
    {
        return isConnectedToGoal();
    }

    private bool isConnectedToGoal()
    {
        foreach (Vector2 index in thisGoalPoints)
        {
            if (!connectedState.curConnected.Contains(board.getBlock(index).node))
            {
                return false;
            }
        }
        return true;
    }
}
