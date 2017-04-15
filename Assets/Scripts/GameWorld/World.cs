using UnityEngine;
using System.Collections;

/**
 * The World is the physical space in the game. It closely relates to screen position
 * thus needs to know the ratio of screen to world coordinates
 * 
 * */
public class World : MonoBehaviour {

    private Vector2 gameSize;
    public UnityEngine.Vector2 GameSize
    {
        get { return gameSize; }
        set { gameSize = value; }
    }

    private float scaleFactor = 9.4f;

    public Transform minGameWorldTransform;
    public Transform maxGameWorldTransform;
    
    public void addObjectToWorld(int i, int j, GameObject gameobject)
    {
        gameobject.transform.position = getWorldPointForIndex(i, j);
        gameobject.transform.localScale = getWorldCellScale();
    }

    public Vector3 getWorldCellScale()
    {
        return new Vector3(scaleFactor / GameSize.x, scaleFactor / GameSize.y, 1);
    }

    public Vector2 getWorldPointForIndex(int i, int j)
    {
        Vector2 minGameWorldPoint = minGameWorldTransform.position;
        Vector2 maxGameWorldPoint = maxGameWorldTransform.position;
        return new Vector2(i * (maxGameWorldPoint.x - minGameWorldPoint.x) / GameSize.x + minGameWorldPoint.x,
                j * (maxGameWorldPoint.y - minGameWorldPoint.y) / GameSize.y + minGameWorldPoint.y);
    }

    public void swapObjectLocations(GameObject block1GO, GameObject block2GO)
    {
        Vector3 oldPos = block1GO.transform.position;
        block1GO.transform.position = block2GO.transform.position;
        block2GO.transform.position = oldPos;
    }

}
