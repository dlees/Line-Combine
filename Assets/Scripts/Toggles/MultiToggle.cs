using UnityEngine;
using System.Collections;

public class MultiToggle : Toggle {

    public Toggle[] toggles;

    public override void toggle(bool value)
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.toggle(value);
        }
    }

}
