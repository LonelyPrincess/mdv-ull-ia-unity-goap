// carryDefeated
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryDefeated : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag(ResourceTypes.Bed);
        if (target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("pickupDefeated");
        inventory.RemoveItem(target);
        return true;
    }
}
