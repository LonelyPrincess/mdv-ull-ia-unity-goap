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

        // Free arena slot in which the character was knocked out
        WorldResources resources = GWorld.Instance.GetSharedResources();
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        inventory.RemoveItem(currentArenaSlot);
        resources.AddResource(ResourceTypes.ArenaSlot, currentArenaSlot);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableArenaSlots, 1);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("defeated");
        WorldResources resources = GWorld.Instance.GetSharedResources();
        resources.AddResource(WorldStateProps.WarriorsAwaitingTreatment, this.gameObject);
        GWorld.Instance.GetWorld().ModifyState("warriorsAwaitingTreatment", 1);
        return true;
    }
}
