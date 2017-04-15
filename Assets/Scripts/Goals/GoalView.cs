using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalView : MonoBehaviour {

    public GoalCondition condition;
    public Text messageBox;
    public Toggle toggle;

	void Start () 
    {
	    messageBox.text = condition.getGoalMessage();
	}
	
	void Update ()
    {
        messageBox.text = condition.getGoalMessage();
        toggle.toggle(condition.isGoalSatisfied());
	}
}
