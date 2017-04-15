using UnityEngine;
using System.Collections;

/**
 * A view of a tile that has pipes in it.
*/
public class PipesTile : MonoBehaviour {
    public Sprite[] tileset;
    public Sprite[] connectedTileset;
    public GameObject tileObject;
    public int pipeLayoutType;   

    public void setupBasedOnBlockTypeInTileset(int type)
    {
        tileObject.GetComponent<SpriteRenderer>().sprite = tileset[type];
        pipeLayoutType = type;
    }

    public void markConnected()
    {
        tileObject.GetComponent<SpriteRenderer>().sprite = connectedTileset[pipeLayoutType];
    }

    public void markDisconnected()
    {
        tileObject.GetComponent<SpriteRenderer>().sprite = tileset[pipeLayoutType];
    }



}
