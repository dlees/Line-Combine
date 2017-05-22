﻿using UnityEngine;
using System.Collections;

public class GetScoreGoalCondition : GoalCondition
{
    public int scoreToAchieve;
    public GameEvaluator evaluator;

    public override string getGoalMessage()
    {
        return "Earn " + scoreToAchieve + " points";
    }

    public override bool isConditionSatisfied()
    {
        return evaluator.score > scoreToAchieve;
    }
}