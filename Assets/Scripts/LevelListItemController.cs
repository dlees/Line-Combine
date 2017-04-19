using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelListItemController : MonoBehaviour {

    public Text levelName;
    public string levelNameString;

	// Update is called once per frame
	void Update () {
        levelName.text = levelNameString;
	}

    public void selectLevel()
    {

    }
}
