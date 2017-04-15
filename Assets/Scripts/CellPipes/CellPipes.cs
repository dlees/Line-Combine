using UnityEngine;
using System.Collections;

public class CellPipes : MonoBehaviour
{
    public Vector2 boardIndex;
    public Node node;

    public CellPipeContainer container = null;

    public PipesTile tile;

    public void setupBasedOnBlockTypeInTileset(int type)
    {
        tile.setupBasedOnBlockTypeInTileset(type);
        node = new Node(this);
    }
    
    //Index of pipe locations
    public const int TOP_PIPE = 0;
    public const int RIGHT_PIPE = 1;
    public const int BOTTOM_PIPE = 2;
    public const int LEFT_PIPE = 3;


    private int[,] tileSetPipeTypesByLocation = {
         { 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0 }, // top
         { 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0 }, // right
         { 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 }, // bottom
         { 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0 }  // left
    };

    // TODO: don't rely on order of pipes locations
    public int getPipeAtLocation(int location)
    {
        return tileSetPipeTypesByLocation[location, tile.pipeLayoutType];
    }

    public int getPipeLayoutType()
    {
        return tile.pipeLayoutType;
    }

    public void markConnected()
    {
        tile.markConnected();
    }

    public void markDisconnected()
    {
        tile.markDisconnected();
    }

    private Vector3 screenPoint;
    private Vector3 offset;
    void OnMouseDown()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            select();
        }
    }

    public void select()
    {
         GetComponent<SpriteRenderer>().enabled = true;
         GameObject go = GameObject.FindGameObjectWithTag("GameController");
         go.GetComponent<CellPipeSelector>().triggerSelection(this.gameObject);
    }

    public void unselect()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
