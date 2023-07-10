using UnityEngine;

public class BeCarried : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag(ResourceTags.Bed);
        if (target == null) {
            Debug.Log("An assigned bed could not be found!");
            return false;
        }

        // Free arena slot in which the character was knocked out
        WorldResources resources = GWorld.Instance.GetSharedResources();
        GameObject currentArenaSlot = inventory.FindItemWithTag(ResourceTags.ArenaSlot);
        inventory.RemoveItem(currentArenaSlot);
        resources.AddResource(ResourceTypes.AvailableArenaSlots, currentArenaSlot);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableArenaSlots, 1);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("defeated");

        // Add self to list of warriors awaiting treatment
        WorldResources resources = GWorld.Instance.GetSharedResources();
        resources.AddResource(ResourceTypes.WarriorsAwaitingTreatment, this.gameObject);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.WarriorsAwaitingTreatment, 1);
        return true;
    }
}
