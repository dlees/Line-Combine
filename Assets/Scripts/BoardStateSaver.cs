using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BoardStateSaver : MonoBehaviour {

    public void saveBoard(Board board, string levelName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(getFileName(levelName));

        BoardState boardState = new BoardState(board);

        binaryFormatter.Serialize(file, boardState);
        file.Close();
        Debug.Log("Saved " + getFileName(levelName));

    }

    public int[,] loadBoardState(string levelName)
    {
        if (File.Exists(getFileName(levelName)))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(getFileName(levelName), FileMode.Open);
            BoardState boardState = (BoardState)binaryFormatter.Deserialize(file);
            file.Close();

            return boardState.boardState;
        }
        else
        {
            Debug.Log("Can't find " + getFileName(levelName));
            return null;
        }
        
    }

    private string getFileName(string levelName)
    {
        return Application.persistentDataPath + "/boardLayouts-" + levelName + ".dat";
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
