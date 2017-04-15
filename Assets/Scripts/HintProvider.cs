using UnityEngine;
using System.Collections;

public class HintProvider : MonoBehaviour {

    public CellPool pool;
    public Background background;

    public GameObject hintIconPrefab;

    private int[,] solution;

    public void setSize(int width, int height)
    {
        solution = new int[width, height];
    }

    public void addToSolution(int x, int y, int type)
    {
        solution[x, y] = type;
    }

    public void placeRandomHint()
    {
        int xindex = Random.Range(1, solution.GetLength(0)-1);
        int yindex = Random.Range(1, solution.GetLength(1)-1);

        Debug.Log(xindex + "," + yindex);

        GameObject inBoard = background.getObject(xindex, yindex); 
        createHintAtGameObject(inBoard);

        GameObject poolItem = pool.getObjectOfType(solution[xindex, yindex]);

        GameObject hintIcon = (GameObject)Instantiate(hintIconPrefab);
        hintIcon.transform.position = poolItem.transform.position;
        hintIcon.transform.parent = poolItem.transform;
        hintIcon.transform.localScale = 1.1f * Vector3.one;        
    }

    private void createHintAtGameObject(GameObject go)
    {
        GameObject hintIcon = (GameObject)Instantiate(hintIconPrefab);
        hintIcon.transform.position = go.transform.position;
        hintIcon.transform.localScale = go.transform.localScale;
    }
    
}
