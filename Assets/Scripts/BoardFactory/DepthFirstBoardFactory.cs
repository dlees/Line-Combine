using UnityEngine;
using System.Collections;

public class DepthFirstBoardFactory : BoardFactory
{
    public GameObject block;
    public Vector2 boardSize;
    
    public CellPool pool;


    public override void createBoard(Board board, Background background)
    {
        Stack toSearch = new Stack();

        GameObject brick = (GameObject)Instantiate(block);
        board.placeBlock(0, 4, brick);
        brick.GetComponent<CellPipes>().setupBasedOnBlockTypeInTileset(8);

        toSearch.Push(brick);

        while (toSearch.Count > 0)
        {
            GameObject searching = (GameObject) toSearch.Pop();



        }

    }
}
