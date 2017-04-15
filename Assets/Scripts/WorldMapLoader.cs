using UnityEngine;
using System.Collections;

public class WorldMapLoader : MonoBehaviour {

    public CellPool pool;
    public BoardStateSaver boardStateSaver;

	void Start () {
        for (int i = 0; i < 13; i++)
        {
            putLevelInMap("level" + i.ToString());
        }

	}

    private void putLevelInMap(string levelName)
    {
        int[,] state = boardStateSaver.loadBoardState(levelName);
        if (state == null) { return; }

        for (int i = 0; i < state.GetLength(0); i++)
        {
            for (int j = 0; j < state.GetLength(1); j++)
            {
                pool.addTemplate(state[j, i]);

            }
        }
    }
	
}
