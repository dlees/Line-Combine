using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CellPipeSelector : MonoBehaviour {
        
    private GameObject selected = null;

    public Board board;

    public ActionManager actionManager;

    public CellPipesMover cellPipesMover;

    public void triggerSelection(GameObject curSelected)
    {
        if (selected == null)
        {            
            selected = curSelected;
        }
        else
        {
            CellPipes selectedPipes = selected.GetComponent<CellPipes>();
            selectedPipes.unselect();
            CellPipes curSelectedPipes = curSelected.GetComponent<CellPipes>();
            curSelectedPipes.unselect();
            
            if (shouldSwitchSelection(selectedPipes, curSelectedPipes))
            {
                selected = null;
                curSelectedPipes.select();
                return;
            }   

            Action action = createAction(selectedPipes, curSelectedPipes);

            actionManager.performAction(action);

            selected = null;     
        }
    }

    private bool shouldSwitchSelection(CellPipes selected, CellPipes curSelected)
    {
        return
            // just in CellPool
            (selected.container == curSelected.container && selected.container != board) ||
            // Both are empty blocks
            (selected.getPipeLayoutType() == curSelected.getPipeLayoutType() && selected.getPipeLayoutType() == 15);
    }

    private Action createAction(CellPipes selectedPipes, CellPipes curSelectedPipes)
    {
        CellPipeContainer selectedContainer = selectedPipes.container;
        CellPipeContainer curSelectedContainer = curSelectedPipes.container;

        if (selectedContainer != board)
        {
            return new MoveFromPoolToBoardAction(selectedPipes, curSelectedPipes, cellPipesMover);
        }
        else if (curSelectedContainer != board)
        {
            return new MoveFromPoolToBoardAction(curSelectedPipes, selectedPipes, cellPipesMover);
        }
        else
        {
            return new SwapInBoardAction(selectedPipes, curSelectedPipes, board);
        }
    }
            
    public void cancelSelection()
    {
        selected = null;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                Collider2D hit = Physics2D.OverlapPoint(touchPos);
                if (hit)
                {
                    hit.transform.gameObject.GetComponent<CellPipes>().select();
                }
            }
        }
    }

}
