using UnityEngine;
using System.Collections;

public class ActionStack : MonoBehaviour {
    Stack undoStack = new Stack();
    Stack redoStack = new Stack();

    public bool canUndo()
    {
        return undoStack.Count != 0;
    }

    public bool canRedo()
    {
        return redoStack.Count != 0;
    }

    public void undo()
    {
        Action action = (Action) undoStack.Pop();
        action.undo();
        redoStack.Push(action);
    }

    public void redo()
    {
        Action action = (Action)redoStack.Pop();
        action.perform();
        undoStack.Push(action);
    }

    public void addAction(Action action)
    {
        undoStack.Push(action);
    }

    public void Clear()
    {
        undoStack.Clear();
        redoStack.Clear();
    }
}
