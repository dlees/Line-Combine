using UnityEngine;
using System.Collections;

public class ToggleController : MonoBehaviour {

    public Condition condition;
    public Toggle toggle;

	void Update () {
        toggle.toggle(condition.isConditionSatisfied());
	}
}
