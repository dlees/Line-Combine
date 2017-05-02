using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BoardStateSaver : MonoBehaviour {
    
    public void saveScore(bool[] goalConditions, string levelName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(getFileName("bestScore-" + levelName));
        binaryFormatter.Serialize(file, goalConditions);
        file.Close();
    }

    public bool[] loadBestScore(string levelName)
    {
        if (File.Exists(getFileName("bestScore-" + levelName)))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(getFileName("bestScore-" + levelName), FileMode.Open);
            bool[] goalConditions = (bool[])binaryFormatter.Deserialize(file);
            file.Close();
            return goalConditions;
        }
        else
        {
            Debug.Log("Can't find " + getFileName("bestScore-" + levelName));
            return new bool[]{ false, false, false};
        }
    }

    public void saveBoard(Board board, string levelName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(getFileName("boardLayouts-" + levelName));

        BoardState boardState = new BoardState(board);

        binaryFormatter.Serialize(file, boardState);
        file.Close();

    }

    public int[,] loadBoardState(string levelName)
    {
        if (File.Exists(getFileName("boardLayouts-" + levelName)))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(getFileName("boardLayouts-" + levelName), FileMode.Open);
            BoardState boardState = (BoardState)binaryFormatter.Deserialize(file);
            file.Close();

            return boardState.boardState;
        }
        else
        {
            Debug.Log("Can't find " + getFileName("boardLayouts-" + levelName));
            return null;
        }
        
    }

    public void clearData(string[] levelNames)
    {
        foreach (string levelName in levelNames)
        {
            if (File.Exists(getFileName("boardLayouts-" + levelName)))
            {
                File.Delete(getFileName("boardLayouts-" + levelName));
            }

            if (File.Exists(getFileName("bestScore-" + levelName)))
            {
                File.Delete(getFileName("bestScore-" + levelName));
            }
        }
    }

    private string getFileName(string levelName)
    {
        return Application.persistentDataPath + "/" + levelName + ".dat";
    }

    [System.Serializable]
    class BoardState
    {
        public BoardState(Board board)
        {
            boardState = board.getCellTypes();
        }
        public int[,] boardState;
    }
}
