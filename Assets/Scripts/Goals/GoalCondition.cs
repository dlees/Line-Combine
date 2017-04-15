using UnityEngine;
using System.Collections;

abstract public class GoalCondition : MonoBehaviour {

    public abstract string getGoalMessage();
    public abstract bool isGoalSatisfied();
}
