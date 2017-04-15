using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomBoardFactory : BoardFactory
{
    public GameObject block;
    public Vector2 boardSize;

    public CellPool pool;

    public override void createBoard(Board board, Background background)
    {
        // really i should be setting the world's size and having that trigger
        // the init of these objects.
        board.setSize(boardSize);
        background.setSize(boardSize);

        if (pool != null)
        {
            pool.startup();
        }

        for (int i = 0; i < boardSize.x; i++)
        {
            for (int j = 0; j < boardSize.y; j++)
            {
                if (pool == null || (i==0 && j==4) || (i==4 && j==0))
                {
                    GameObject brick = (GameObject)Instantiate(block);
                    board.placeBlock(i, j, brick);
                    brick.GetComponent<CellPipes>().setupBasedOnBlockTypeInTileset(8);
                }
                else
                {

                    board.placeBlock(i, j, createCellWithPipes(15));
                    pool.addType(Random.Range(0, 14));
                }

                background.addObject(i, j, "normal");
            }
        }
        
        
        /// Really there could be another class that combines Network 
        /// and Background (that's what board used to be lol)
        background.changeObject(0, 4, "start");
        background.changeObject(4, 0, "goal");
        background.changeObject(0, 0, "bonus");
        background.changeObject(4, 4, "bonus");

        board.maxConnectionsPossible = 25;
    }

    private GameObject createCellWithPipes(int pipeTypes)
    {
        GameObject cell = (GameObject)Instantiate(block);
        cell.GetComponent<CellPipes>().setupBasedOnBlockTypeInTileset(pipeTypes);
        return cell;
    }
    
}
