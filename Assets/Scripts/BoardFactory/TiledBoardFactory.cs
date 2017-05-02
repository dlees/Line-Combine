using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

using TiledSharp;

public class TiledBoardFactory : BoardFactory
{
    public CellPipesFactory cellPipesFactory;
    public CellPool pool;
    public HintProvider hintProvider;

    public string levelName;
    public override string getLevelName()
    {
        return levelName;
    }

    const int LINKS_LAYER = 0;
    const int SPECIAL_TILES_LAYER = 1;

    public Text messageText;
    
    public Stream GenerateStreamFromString(string s)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public override void createBoard(Board board, Background background)
    {
        TextAsset level = (TextAsset)Resources.Load("Levels/" + levelName);
        Stream stream = GenerateStreamFromString(level.text);
        TmxMap map = new TmxMap(stream);
        
        Vector2 boardSize = new Vector2(map.Width, map.Height);
        board.setSize(boardSize); 
        background.setSize(boardSize);
        hintProvider.setSize(map.Width, map.Height);

        if (pool != null)
        {
            pool.startup();
        }

        putTilesInBoard(ref map, board, background);

        //pool.logNumOfEachType();
        if (pool == null)
        {
            randomize(ref boardSize, board);
        }
    }

    private void putTilesInBoard(ref TiledSharp.TmxMap map, Board board, Background background)
    {
        int connectionsPossible = 0;
        for (var i = 0; i < map.Layers[LINKS_LAYER].Tiles.Count; i++)
        {
            int gid = map.Layers[LINKS_LAYER].Tiles[i].Gid;
            int cellType = map.Layers[SPECIAL_TILES_LAYER].Tiles[i].Gid;
            int xindex = (i % map.Width);
            int yindex = map.Height - 1 - (i / map.Width);

            setupPipes(gid, cellType, xindex, yindex, board);

            if (pool != null)
            {
                addPipeToPool(gid, cellType);
            }
            setupBackground(cellType, xindex, yindex, background);

            if (gid != 0 && gid != 16)
            {
                connectionsPossible++;
            }               
        }
        board.maxConnectionsPossible = connectionsPossible;
    }

    private const int START_TYPE = 19;
    private const int GOAL_TYPE = 20;
    private void addPipeToPool(int gid, int cellType)
    {
        if (gid != 0 && gid != 16 && cellType != START_TYPE && cellType != GOAL_TYPE)
        {
            pool.addType(gid-1);
        }
    }

    private void setupPipes(int gid, int cellType, int xindex, int yindex, Board board)
    {
        if (pool == null || cellType == START_TYPE || cellType == GOAL_TYPE)
        {            
            GameObject cell = createCellWithPipes(gid == 0 ? 15 : gid - 1);
            board.placeBlock(xindex, yindex, cell);
            return;
        }

        GameObject emptyCell = createCellWithPipes(15);
        board.placeBlock(xindex, yindex, emptyCell);

        hintProvider.addToSolution(xindex, yindex, gid-1);
    }

    private GameObject createCellWithPipes(int pipeTypes)
    {
        return cellPipesFactory.createCellWithPipes(pipeTypes);
    }
    
    // At this rate, we should just use tiled for this...
    private void setupBackground(int gid, int xindex, int yindex, Background background)
    {
        switch (gid)
        {
            case 17:
                background.addObject(xindex, yindex, "wall");
                break;
            case 18:
                background.addObject(xindex, yindex, "bonus");
                break;
            case START_TYPE:
                background.addObject(xindex, yindex, "start");
                break;
            case GOAL_TYPE:
                background.addObject(xindex, yindex, "goal");
                break;
            default:
                background.addObject(xindex, yindex, "normal");
                break;
        }
    }

    private void randomize(ref Vector2 boardSize, Board board)
    {
        for (int i = 0; i < boardSize.x * boardSize.y; i++)
        {
            board.swapBlocks(board.getRandomInnerBlock(), board.getRandomInnerBlock());
        }
    }
}
