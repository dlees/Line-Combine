using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public BoardFactory boardFactory;

    public Board board;
    public Background background;
    public CellPool pool;
    public GameEvaluator evaluator;
    public ActionManager actionManager;
    public BestScoreController bestScore;

    public BoardStateSaver boardStateSaver;
    public string currentLevelName;

    public CellPipesFactory cellPipesFactory;

    void Start()
    {
        StartWithoutSavedProgress();
    }

    public void Restart()
    {
        RestartWithoutSavedProgress();
    }

    public void RestartWithoutSavedProgress()
    {
        deleteCurrentGame();
        
        StartWithoutSavedProgress();        
    }

    public void RestartFromSavedProgress()
    {
        deleteCurrentGame();

        StartFromSavedProgress();
    }

    private void StartFromSavedProgress()
    {
        boardFactory.createBoard(board, background);
        currentLevelName = boardFactory.getLevelName();
        evaluator.loadInfoFromBackground();
        if (currentLevelName != "random")
        {
            loadProgressFromSavedState(board);
        }

        board.setupGraph();
        evaluator.evaluateConnections();
        bestScore.loadBestScore(currentLevelName);
    }

    private void StartWithoutSavedProgress()
    {
        boardFactory.createBoard(board, background);
        currentLevelName = boardFactory.getLevelName();
        evaluator.loadInfoFromBackground();

        board.setupGraph();
        evaluator.evaluateConnections();
        bestScore.loadBestScore(currentLevelName);
    }

    private void deleteCurrentGame()
    {
        if (bestScore.isCurrentBestScore()) {
            boardStateSaver.saveBoard(board, currentLevelName);
            bestScore.saveBestScore(currentLevelName);
        }

        // Here you can see similarities between board and background...
        // This is bound to turn into a list or map
        board.deleteAll();
        background.deleteAll();
        pool.deleteAll();
        evaluator.reset();
        actionManager.reset();
    }

    private void loadProgressFromSavedState(Board board)
    {
        int[,] state = boardStateSaver.loadBoardState(currentLevelName);
        if (state == null) { return; }

        for (int i = 1; i < state.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < state.GetLength(1) - 1; j++)
            {
                if (state[i, j] != 15)
                {
                    pool.removeType(state[i, j]);
                    GameObject newInBoard = cellPipesFactory.createCellWithPipes(state[i, j]);
                    CellPipes newInBoardPipes = newInBoard.GetComponent<CellPipes>();
                    newInBoardPipes.boardIndex = new Vector2(i, j);
                    Destroy(board.getBlock(i, j).gameObject);
                    board.addCellPipes(newInBoardPipes);
                }
            }
        }
    }

    public void setBoardFactory(BoardFactory factory)
    {
        boardFactory = factory;
    }
	
}
