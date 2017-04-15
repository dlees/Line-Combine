using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Contains current information about all nodes connected to 
 * the startIndex in the board
 * */
public class ConnectedState : MonoBehaviour {

    public Board board;

    public HashSet<Node> curConnected;
    public HashSet<Vector2> connectedIndicies;

    // This is set in GameEvaluator loadInfoFromBackground
    public Vector2 startIndex;

    public void updateState()
    {
        curConnected = board.getBlock(startIndex).node.getConnected();
        connectedIndicies = getConnectedIndicies(curConnected);
    }

    public void reset()
    {
        curConnected.Clear();
        connectedIndicies.Clear();
    }

    private HashSet<Vector2> getConnectedIndicies(HashSet<Node> curConnected)
    {
        HashSet<Vector2> connectedIndicies = new HashSet<Vector2>();
        foreach (Node node in curConnected)
        {
            connectedIndicies.Add(node.block.boardIndex);
        }
        return connectedIndicies;
    }
    
}
