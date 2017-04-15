using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Really should be Network
// Begs the question tho, how are multiple pipetypes implemented?
// Multiple of these classes should be the answer.
public class Board : MonoBehaviour, CellPipeContainer {
    private GameObject[,] board;

    private Vector2[] neighborList = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };

    public World world;
    public GameEvaluator evaluator;

    public int maxConnectionsPossible = 25;

    public void setSize(Vector2 size)
    {
        board = new GameObject[(int)size.x, (int)size.y];
    }
    
    // This is now a strange hybrid between model and view
    public void placeBlock(int i, int j, GameObject block)
    {
        // Model
        board[i, j] = block;

        // View // Then again, it's also the model because is really the position of the block in the world..
        // I've decided that the world is a view really. (Technically it's the model for the view, but for us it
        // really serves as teh view)
        world.addObjectToWorld(i, j, block);        

        // Kinda both?
        block.GetComponent<CellPipes>().boardIndex = new Vector2(i, j);
        block.GetComponent<CellPipes>().container = this;
    }
    
    public void swapBlocks(GameObject block1GO, GameObject block2GO)
    {
        world.swapObjectLocations(block1GO, block2GO);

        CellPipes block1 = block1GO.GetComponent<CellPipes>();
        CellPipes block2 = block2GO.GetComponent<CellPipes>();

        Vector2 oldIndex = block1.boardIndex;
        block1.boardIndex = block2.boardIndex;
        block2.boardIndex = oldIndex;

        board[(int)block2.boardIndex.x, (int)block2.boardIndex.y] = block2GO;
        board[(int)block1.boardIndex.x, (int)block1.boardIndex.y] = block1GO;

        setupLinksForCellAndNeighbors(ref block1.boardIndex);
        setupLinksForCellAndNeighbors(ref block2.boardIndex);

        evaluator.evaluateConnections();
    }

    public void addCellPipes(CellPipes pipes)
    {
        placeBlock((int)pipes.boardIndex.x, (int)pipes.boardIndex.y, pipes.gameObject);

        setupLinksForCellAndNeighbors(ref pipes.boardIndex);
        evaluator.evaluateConnections();
    }
    
    public void runFunctionForAllObjects(System.Action<int, int> func)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                func(i, j);
            }
        }
    }

    public int[,] getCellTypes()
    {
        int[,] typeInfo = new int[board.GetLength(0), board.GetLength(1)];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                typeInfo[i, j] = getBlock(i, j).getPipeLayoutType();
            }
        }
        return typeInfo;
    }

    public void setupGraph()
    {
        runFunctionForAllObjects(setupLinksForCell);
    }
    
    private void setupLinksForCellAndNeighbors(ref Vector2 selectedIndex)
    {
        setupLinksForCell((int)selectedIndex.x, (int)selectedIndex.y);
        foreach (Vector2 neightborSide in neighborList)
        {
            setupLinksForCell((int)selectedIndex.x + (int)neightborSide.x, (int)selectedIndex.y + (int)neightborSide.y);
        }
    }

    private void setupLinksForCell(int i, int j)
    {
        if (i >= board.GetLength(0) || i < 0 || j < 0 || j >= board.GetLength(1))
        {
            return;
        }

        CellPipes block = getBlock(i, j);

        if (block == null)
        {
            return;
        }

        block.node.nodes = new List<Node>();

        setupLinksWithNeighbor(block, i + 1, j, CellPipes.RIGHT_PIPE, CellPipes.LEFT_PIPE);
        setupLinksWithNeighbor(block, i - 1, j, CellPipes.LEFT_PIPE, CellPipes.RIGHT_PIPE);
        setupLinksWithNeighbor(block, i, j + 1, CellPipes.TOP_PIPE, CellPipes.BOTTOM_PIPE);
        setupLinksWithNeighbor(block, i, j - 1, CellPipes.BOTTOM_PIPE, CellPipes.TOP_PIPE);
    }

    private void setupLinksWithNeighbor(CellPipes block, int i, int j, int blockPipe, int neighborPipe)
    {
        if (i >= board.GetLength(0) || i < 0 || j < 0 || j >= board.GetLength(1))
        {
            return;
        }

        // Don't count blank pipes 
        if ((int)block.getPipeAtLocation(blockPipe) == 0)
        {
            return;
        }

        CellPipes neighbor = getBlock(i, j);

        if (neighbor == null)
        {
            return;
        }

        if ((int)block.getPipeAtLocation(blockPipe) == (int)neighbor.getPipeAtLocation(neighborPipe))
        {
            block.node.nodes.Add(neighbor.node);
        }
    }

    public void deleteAll()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Destroy(board[i, j]);
            }
        }
    }

    public CellPipes getBlock(int i, int j)
    {
        return board[i, j].GetComponent<CellPipes>();
    }

    public CellPipes getBlock(Vector2 index)
    {
        return getBlock((int)index.x, (int)index.y);
    }

    public GameObject getRandomInnerBlock()
    {
        return getBlock(Random.Range(1, board.GetLength(0) - 1), Random.Range(1, board.GetLength(1) - 1)).gameObject;
    }

    public string getBoardInCompressedFormat()
    {
        string compressed = board.GetLength(0).ToString() + " " + board.GetLength(1).ToString() + " ";

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                compressed += getBlock(i, j).getPipeLayoutType().ToString();
            }
        }

        return compressed;
    }
}
