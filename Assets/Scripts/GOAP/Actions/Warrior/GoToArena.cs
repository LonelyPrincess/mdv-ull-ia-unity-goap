using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToArena : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.ArenaSlot);
        if (target == null) {
            Debug.Log("A free arena slot could not be found!");
            return false;
        }

        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableArenaSlots, -1);
        inventory.AddItem(target);

        return true;
    }

    public override bool PostPerform()
    {
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        int arenaId = currentArenaSlot.transform.parent.gameObject.GetInstanceID();
        GWorld.Instance.GetWorld().ModifyState("fightersInArena" + arenaId, 1);
        return true;
    }
}
