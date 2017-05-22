using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsPoster : MonoBehaviour
{
    public BestScoreController bestScore;
    public GameEvaluator evaluator;
    public LevelSelector levelSelector;
    public GameTimer timer;

    int totalConnectedAtStart = 0;
    int starsObtainedAtStart = 0;
    float timeSpentAtStart = 0;

    public void postNextLevelAnalytics()
    {
        Analytics.CustomEvent("levelComplete", new Dictionary<string, object>
          {
            { "totalConnected", evaluator.NumConnectionsToRoot - totalConnectedAtStart},
            { "starsObtained", getStarsObtained() - starsObtainedAtStart },
            { "TimeSpent", timer.getSecondsSoFar() - timeSpentAtStart}, 
            { "LevelId", levelSelector.currentLevel }
          });
    }

    private int getStarsObtained()
    {
        int starsObtained = 0;
        bool[] score = bestScore.GetScore();
        foreach (bool goalScore in score)
        {
            if (goalScore)
            {
                starsObtained++;
            }
        }
        return starsObtained;
    }

    public void resetValuesToCompareAgainst()
    {
        timeSpentAtStart = timer.getSecondsSoFar();
        totalConnectedAtStart = evaluator.NumConnectionsToRoot;
        starsObtainedAtStart = getStarsObtained();
    }

}
