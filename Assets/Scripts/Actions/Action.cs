using UnityEngine;
using System.Collections;

abstract public class Action : MonoBehaviour{
    public bool isUndoable;
    public bool isCountable;

    public Action(bool isUndoable = true, bool isCountable = true)
    {
        this.isUndoable = isUndoable;
        this.isCountable = isCountable;
    }

    public abstract void perform();
    public abstract void undo();

    public abstract string getQuickString();

}

public class SwapInBoardAction : Action
{
    Vector2 oldIndex;
    Vector2 newIndex;
    Board board;

    public SwapInBoardAction(CellPipes pipes1, CellPipes pipes2, Board board)
    {
        oldIndex = pipes1.boardIndex;
        newIndex = pipes2.boardIndex;
        this.board = board;
    }

    public override void perform()
    {
        board.swapBlocks(board.getBlock(oldIndex).gameObject, board.getBlock(newIndex).gameObject);
    }

    public override void undo()
    {
        perform();
    }

    public override string getQuickString()
    {
        return "s " + oldIndex.ToString() + " " + newIndex.ToString();
    }
}

public class MoveFromPoolToBoardAction : Action
{
    int typeInPoolToMove;
    int typeinBoardToReplace;
    Vector2 indexInBoard;
    CellPipesMover cellPipesMover;

    public MoveFromPoolToBoardAction(CellPipes inPool, CellPipes inBoard, CellPipesMover cellPipesMover)
    {
        typeInPoolToMove = inPool.getPipeLayoutType();
        indexInBoard = inBoard.boardIndex;
        typeinBoardToReplace = inBoard.getPipeLayoutType();
        this.cellPipesMover = cellPipesMover;
    }

    public override string getQuickString()
    {
        return "p " + typeInPoolToMove + " " + indexInBoard.ToString();
    }

    public override void perform()
    {
        cellPipesMover.MoveTypeFromPoolToBoard(typeInPoolToMove, (int) indexInBoard.x, (int) indexInBoard.y);    
    }

    public override void undo()
    {
        cellPipesMover.MoveTypeFromPoolToBoard(typeinBoardToReplace, (int)indexInBoard.x, (int)indexInBoard.y);
    }
}
