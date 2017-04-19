using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour {

    public RandomBoardFactory randomBoardFactory;
    public TiledBoardFactory tiledBoardFactory;

    public GameManager gameManager;

    public string[] levelOrder;

    public string currentLevel = "level1";

	void Awake () {
        GameObject persistentGameObject = GameObject.Find("PersistentState");

        levelOrder = LevelProvider.getLevels();

        if (persistentGameObject != null)
        {
            PersistentState persistentScript = persistentGameObject.GetComponent<PersistentState>();

            if (persistentScript.currentLevel == "random")
            {
                gameManager.setBoardFactory(randomBoardFactory);
            } 
            else
            {
                tiledBoardFactory.levelName = persistentScript.currentLevel;
                gameManager.setBoardFactory(tiledBoardFactory);
                currentLevel = persistentScript.currentLevel;
            }
        }
	}

    public void NextLevel()
    {
        currentLevel = getNextLevel();

        Debug.Log(currentLevel);

        tiledBoardFactory.levelName = currentLevel;
        gameManager.setBoardFactory(tiledBoardFactory);
        gameManager.Restart();
    }
    
    private string getNextLevel() {
        for (int i = 0; i < levelOrder.Length; i++)
        {
            if (levelOrder[i] == currentLevel)
            {
                return levelOrder[(i + 1) % levelOrder.Length];
            }
        }
        return "level4";
    }
}
