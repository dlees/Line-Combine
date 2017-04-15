using UnityEngine;
using System.Collections;

abstract public class BoardFactory : MonoBehaviour
{
    abstract public void createBoard(Board board, Background background);

    virtual public string getLevelName() { return "random"; }
}