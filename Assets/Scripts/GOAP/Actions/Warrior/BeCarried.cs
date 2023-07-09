using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeCarried : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Bed");
        if (target == null) {
            Debug.Log("An assigned bed could not be found!");
            return false;
        }

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("defeated");
        GWorld.Instance.GetWorld().ModifyState("warriorsAwaitingTreatment", 1);
        return true;
    }
}
