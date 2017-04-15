using UnityEngine;
using System.Collections;

public class CellPipesMover : MonoBehaviour {

    public CellPool pool;
    public Board board;
    public CellPipesFactory cellPipesFactory;

    public CellPipesMover(CellPool pool, Board board, CellPipesFactory cellPipesFactory) {
         this.pool = pool;
         this.board = board;
         this.cellPipesFactory = cellPipesFactory;
    }

    public void MoveTypeFromPoolToBoard(int typeInPool, int xindex, int yindex)
    {
        CellPipes inBoard = board.getBlock(xindex, yindex);

        GameObject newInBoard = cellPipesFactory.createCellWithPipes(typeInPool);
        CellPipes newInBoardPipes = newInBoard.GetComponent<CellPipes>();
        newInBoardPipes.boardIndex = inBoard.boardIndex;

        board.addCellPipes(newInBoardPipes);

        pool.removeType(typeInPool);
        pool.addType(inBoard.getPipeLayoutType());

        Destroy(inBoard.gameObject);
    }
}
