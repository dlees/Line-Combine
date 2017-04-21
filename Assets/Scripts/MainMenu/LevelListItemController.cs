using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelListItemController : MonoBehaviour {

    public Text levelName;
    public string levelNameString;
    public BestScoreController bestScoreController;
    public Button levelButton;
    
    // Update is called once per frame
    void Update () {
        levelName.text = levelNameString;
	}

    public void disableLevel()
    {
        levelButton.interactable = false;
    }

    public void selectLevel()
    {
        GameObject.Find("ModifiableState").GetComponent<ModifiableState>().CurrentLevel = levelNameString;
    }
}
