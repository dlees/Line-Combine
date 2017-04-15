using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameEvaluator : MonoBehaviour {

    public Board board;
    public Background background;

    public Text connectedNumberText;
    public Text scoreText;

    public GameObject fadingTextPrefab;
    
    private HashSet<Node> previouslyConnected = new HashSet<Node>();
    private HashSet<Vector2> previouslyConnectedIndicies = new HashSet<Vector2>();

    private List<Vector2> bonusPoints = new List<Vector2>();
    public List<Vector2> goalPoints = new List<Vector2>();

    public ConnectedState connectedState;

    public GoalView nextLevelGoalView;
    public GoalView bonusPointsGoalView;

    private int numConnectionsToRoot = 0;
    public int NumConnectionsToRoot
    {
        get { return numConnectionsToRoot; }
    }

    public int score = 0;
    
    public void reset()
    {
        bonusPoints.Clear();
        goalPoints.Clear();
        previouslyConnectedIndicies.Clear();
        previouslyConnected.Clear();

        connectedState.reset();  
    }

    public void loadInfoFromBackground()
    {
        List<Vector2> startIndicies = background.getCellsOfType("start");
        connectedState.startIndex = startIndicies[0];

        bonusPoints = background.getCellsOfType("bonus");
        goalPoints = background.getCellsOfType("goal");

        nextLevelGoalView.condition = new ConnectStartToPointsCondition(goalPoints, "Connect Blue to Red", connectedState, board);
        bonusPointsGoalView.condition = new ConnectStartToPointsCondition(bonusPoints, "Connect Blue to Green", connectedState, board);

        List<Vector2> walls = background.getCellsOfType("wall");
        
        startIndicies.ForEach(x => { disableCollisions(x); } );
        goalPoints.ForEach(x => { disableCollisions(x); } );
        walls.ForEach(x => { disableCollisions(x); });
    }

    // Hmm this is strange logic. Is it a controller? We are basically telling
    // the game that we can't change walls. This shouldn't be here, because this 
    // class should simply be a view on top of the game world/network
    //
    // What we really need is a "game rule" that looks at the "Background" (the game world)
    // And decides what to do with the information there.
    public void disableCollisions(Vector2 index)
    {
        board.getBlock((int) index.x, (int)index.y).GetComponent<BoxCollider2D>().enabled = false;
    }

    public void evaluateConnections()
    {
        connectedState.updateState();
        HashSet<Node> curConnected = connectedState.curConnected;
        HashSet<Vector2> connectedIndicies = connectedState.connectedIndicies;

        numConnectionsToRoot = curConnected.Count;

        connectedNumberText.text = NumConnectionsToRoot.ToString() + "/" + board.maxConnectionsPossible.ToString();
        
        score = getScore(curConnected);
        scoreText.text = score.ToString();

        IEnumerable<Node> justDisconnected = previouslyConnected.Except(curConnected);
        IEnumerable<Node> justConnected = curConnected.Except(previouslyConnected);
        foreach (Node node in justDisconnected)
        {
            node.block.markDisconnected();
        }

        foreach (Node node in justConnected)
        {
            node.block.markConnected();
        }

        IEnumerable<Vector2> justDisconnectedIndicies = previouslyConnectedIndicies.Except(connectedIndicies);
        IEnumerable<Vector2> justConnectedIndicies = connectedIndicies.Except(previouslyConnectedIndicies);
        foreach (Vector2 index in bonusPoints)
        {
            if (justConnectedIndicies.Contains(index))
            {
                createFadingTextAtBlock(index, "+5", Color.green);
            }
            else if (justDisconnectedIndicies.Contains(index))
            {
                createFadingTextAtBlock(index, "-5", Color.red);
            }
        }
//         foreach (Vector2 index in goalPoints)
//         {
//             if (justConnectedIndicies.Contains(index))
//             {
//                 createFadingTextAtBlock(index, "Red", Color.green);
//             }
//             else if (justDisconnectedIndicies.Contains(index))
//             {
//                 createFadingTextAtBlock(index, "Red", Color.red);
//             }
//         }

        previouslyConnected = curConnected;
        previouslyConnectedIndicies = connectedIndicies;
    }

    private void createFadingTextAtBlock(Vector2 blockIndex, string text, Color color)
    {
        fadingTextPrefab.GetComponent<Text>().text = text;
        fadingTextPrefab.GetComponent<Text>().color = color;
        GameObject fadingText = (GameObject)Instantiate(fadingTextPrefab);
        fadingText.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas").transform, false);
        fadingText.transform.position = board.getBlock(blockIndex).transform.position;
    }

    private int getScore(HashSet<Node> curConnected)
    {
        int score = 0;
        foreach (Node node in curConnected)
        {
            score += 1;
            if (bonusPoints.Contains(node.block.boardIndex))
            {
                score += 4;
            }
        }
        return score;
    }


}
