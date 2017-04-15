using UnityEngine;

public class CellPoolItem {
    public GameObject block;
    public int numAvailable;

    public CellPoolItem(GameObject block_, int numAvailable_)
    {
        block = block_;
        numAvailable = numAvailable_;
    }
}
