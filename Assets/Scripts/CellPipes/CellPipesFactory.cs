using UnityEngine;
using System.Collections;

public class CellPipesFactory : MonoBehaviour  {

    public GameObject block;

    public CellPipesFactory(GameObject block)
    {
        this.block = block;
    }

    public GameObject createCellWithPipes(int pipeTypes)
    {
        GameObject cell = (GameObject)Instantiate(block);
        cell.GetComponent<CellPipes>().setupBasedOnBlockTypeInTileset(pipeTypes);
        return cell;
    }
}
