using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Text title;

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

        startGame();
    }

    private void startGame()
    {
        board.setupGraph();
        bestScore.loadBestScore(currentLevelName);
        evaluator.evaluateConnections();
        title.text = currentLevelName;
    }

    private void StartWithoutSavedProgress()
    {
        boardFactory.createBoard(board, background);
        currentLevelName = boardFactory.getLevelName();
        evaluator.loadInfoFromBackground();

        startGame();
    }

    private void deleteCurrentGame()
    {
        saveBoardIfBest();

        // Here you can see similarities between board and background...
        // This is bound to turn into a list or map
        board.deleteAll();
        background.deleteAll();
        pool.deleteAll();
        evaluator.reset();
        actionManager.reset();
    }

    public void saveBoardIfBest()
    {
        if (bestScore.isCurrentBestScore())
        {
            boardStateSaver.saveBoard(board, currentLevelName);
            bestScore.saveBestScore(currentLevelName);
        }
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

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
