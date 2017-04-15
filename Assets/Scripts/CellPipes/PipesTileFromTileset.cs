using UnityEngine;
using System.Collections;

public class PipesTileFromTileset
{
    /***
     * 
     *    public GameObject[] pipeLocations;
    public Sprite[] pipeTypes;
    public Sprite[] connectedPipeTypes;

    public int[] pipeAtLocation;

    public int pipeLayoutType;
    
    public void setupBasedOnBlockTypeInTileset(int type)
    {
        int[] tileSetPipetypesForTopPipe = { 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0 };
        int[] tileSetPipetypesForRightPipe = { 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0 };
        int[] tileSetPipetypesForBottomPipe = { 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 };
        int[] tileSetPipetypesForLeftPipe = { 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0 };

        int[] chosenPipetypes = {tileSetPipetypesForTopPipe[type], 
                                    tileSetPipetypesForRightPipe[type],
                                    tileSetPipetypesForBottomPipe[type],
                                    tileSetPipetypesForLeftPipe[type]
                                };

        setupBlockWithChosenPipeTypes(chosenPipetypes);
        pipeLayoutType = type;
    }

    private void setupBlockWithChosenPipeTypes(int[] chosenPipeTypes)
    {
        pipeAtLocation = new int[pipeLocations.Length];

        for (int i = 0; i < pipeLocations.Length; i++)
        {
            pipeLocations[i].GetComponent<SpriteRenderer>().sprite = pipeTypes[chosenPipeTypes[i]];
            pipeAtLocation[i] = (chosenPipeTypes[i]);
        }

    }


    public void markConnected()
    {
        for (int i = 0; i < pipeLocations.Length; i++)
        {
            pipeLocations[i].GetComponent<SpriteRenderer>().sprite = connectedPipeTypes[(int)pipeAtLocation[i]];
        }
    }

    public void markDisconnected()
    {
        for (int i = 0; i < pipeLocations.Length; i++)
        {
            pipeLocations[i].GetComponent<SpriteRenderer>().sprite = pipeTypes[(int)pipeAtLocation[i]];
        }
    }
*/
}
