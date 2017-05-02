using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreController : MonoBehaviour {

    public ImageToggle[] togglesForGoals;

    public BoardStateSaver boardStateSaver;

    public GoalView[] goals;

    public int bestOverallScore;

	public bool[] loadBestScore (string levelName) {
        bool[] score = boardStateSaver.loadBestScore(levelName);
        bestOverallScore = calculateOverallScore(score);
        updateToggles(score);
        return score;
	}

    private void updateToggles(bool[] score)
    {
        for (int i = 0; i < score.Length; i++)
        {
            togglesForGoals[i].toggle(score[i]);
        }
    }

    public bool isCurrentBestScore()
    {
        bool[] score = GetScore();
        return bestOverallScore < calculateOverallScore(score);
    }

    public void saveBestScore(string levelName)
    {
        bool[] score = GetScore();
        updateToggles(score);
        boardStateSaver.saveScore(score, levelName);
        bestOverallScore = calculateOverallScore(score);
    }

    private bool[] GetScore()
    {
        bool[] score = new bool[goals.Length];
        for (int i = 0; i < goals.Length; i++)
        {
            score[i] = goals[i].condition.isGoalSatisfied();
        }
        return score;
    }

    private int calculateOverallScore(bool[] score)
    {
        int scorePoints = 0;
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i])
            {
                scorePoints += 1 + (3-i);
            }
        }
        return scorePoints;
    }
}
