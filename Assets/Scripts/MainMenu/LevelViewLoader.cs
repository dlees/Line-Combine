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

        foreach (string levelName in levels) {
            GameObject newListItem = Instantiate(ListItemPrefab) as GameObject;
            newListItem.GetComponent<LevelListItemController>().levelNameString = levelName;
            newListItem.transform.parent = ContentPanel.transform;
            newListItem.transform.localScale = Vector3.one;
        }
    }


}
