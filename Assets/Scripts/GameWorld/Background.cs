using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
// Board has shared code here... Interesting...
// So this isnt just a background. It's a layer.
// The Networks are layers to - they have to be put in the world.
// They have to be created and cleaned up..
public class Background : MonoBehaviour {

    public World world;

    public StringToGameObjectMap backgroundTypes;
    
    private GameObject[,] background;

    private Dictionary<string, List<Vector2>> cellTypeToIndex = new Dictionary<string, List<Vector2>>();

    public void setSize(Vector2 size)
    {
        // TODO: Find a better way to do something with the world
        // Both Board and background rely on this. so it's bad.
        world.GameSize = size;
        background = new GameObject[(int)size.x, (int)size.y];
    }

    public void addObject(int i, int j, string type)
    {
        GameObject gameobject = (GameObject)Instantiate(backgroundTypes.Map[type]);

        background[i, j] = gameobject;

        world.addObjectToWorld(i, j, gameobject);

        addTypeToDict(type, i, j);
    }

    private void addTypeToDict(string type, int i, int j)
    {

        if (!cellTypeToIndex.ContainsKey(type))
        {
            cellTypeToIndex[type] = new List<Vector2>();
        }
        cellTypeToIndex[type].Add(new Vector2(i, j));
    }

    public void changeObject(int i, int j, string type)
    {
        GameObject oldObject = background[i, j];
        addObject(i, j, type);
        Destroy(oldObject); 
        addTypeToDict(type, i, j);
    }

    public List<Vector2> getCellsOfType(string type)
    {
        if (!cellTypeToIndex.ContainsKey(type))
        {
            return new List<Vector2>();
        }
        return cellTypeToIndex[type];
    }

    public void deleteAll()
    {
        for (int i = 0; i < background.GetLength(0); i++)
        {
            for (int j = 0; j < background.GetLength(1); j++)
            {
                Destroy(background[i, j]);
            }
        }
       cellTypeToIndex.Clear();
    }

    public GameObject getObject(int i, int j)
    {
        return background[i, j];
    }

    public GameObject getObject(Vector2 index)
    {
        return getObject((int)index.x, (int)index.y);
    }
}
