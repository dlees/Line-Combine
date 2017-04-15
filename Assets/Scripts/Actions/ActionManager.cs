using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionManager : MonoBehaviour {

    public ActionStack actionStack;

    public void performAction(Action action)
    {
        addToUndoStack(action);

        storeInHistory(action);

        action.perform();
    }

    private void addToUndoStack(Action action)
    {
        actionStack.addAction(action);
    }

    private List<Action> actionHistory = new List<Action>();

    private void storeInHistory(Action action)
    {
        Debug.Log(action.getQuickString());
        actionHistory.Add(action);
    }

    public void reset()
    {
        actionStack.Clear();
    }
}
