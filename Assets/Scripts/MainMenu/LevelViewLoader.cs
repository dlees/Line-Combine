using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewLoader : MonoBehaviour {

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    public Text starCount;

    public BoardStateSaver boardStateSaver;

    // Use this for initialization
    void Start () {
        string[] levels = LevelProvider.getLevels();
        bool lastLevelCompleted = true;

        int totalObtainedStars = 0;
        int totalStarsInGame = 0;

        foreach (string levelName in levels) {
            GameObject newListItem = Instantiate(ListItemPrefab) as GameObject;

            LevelListItemController levelListItemController = newListItem.GetComponent<LevelListItemController>();
            levelListItemController.levelNameString = levelName;
            bool[] score = levelListItemController.bestScoreController.loadBestScore(levelName);

            // If we haven't beat the first challenge in the level, 
            // we can't move on.
            if (!lastLevelCompleted)
            {
                levelListItemController.disableLevel();
            }
            lastLevelCompleted = score[0];

            newListItem.transform.parent = ContentPanel.transform;
            newListItem.transform.localScale = Vector3.one;

            for (int i = 0; i < score.Length; i++)
            {
                totalStarsInGame++;
                if (score[i])
                {
                    totalObtainedStars++;
                }
            }
        }

        starCount.text = totalObtainedStars.ToString() + "/" + totalStarsInGame.ToString();
    }

    public void clearData()
    {
        boardStateSaver.clearData(LevelProvider.getLevels());
        foreach (Transform child in ContentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Start();
    }
}
