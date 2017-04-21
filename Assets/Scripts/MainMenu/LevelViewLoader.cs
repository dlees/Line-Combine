using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewLoader : MonoBehaviour {

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    // Use this for initialization
    void Start () {
        string[] levels = LevelProvider.getLevels();
        bool completedAllSoFar = true;

        foreach (string levelName in levels) {
            GameObject newListItem = Instantiate(ListItemPrefab) as GameObject;

            LevelListItemController levelListItemController = newListItem.GetComponent<LevelListItemController>();
            levelListItemController.levelNameString = levelName;
            bool[] score = levelListItemController.bestScoreController.loadBestScore(levelName);
            
            // If we haven't beat the first challenge in the level, 
            // we can't move on.
            if (score[0] == false)
            {
                completedAllSoFar = false;
            }

            newListItem.transform.parent = ContentPanel.transform;
            newListItem.transform.localScale = Vector3.one;

            if (!completedAllSoFar)
            {
                levelListItemController.disableLevel();
            }
        }
    }


}
