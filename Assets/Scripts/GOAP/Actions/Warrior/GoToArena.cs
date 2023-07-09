using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToArena : GAction
{
    public override bool PrePerform()
    {
        Debug.Log("FIGHT: " + this.name + " is running action " + this.actionName);
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        if (currentArenaSlot != null) {
            Debug.Log("FIGHT: " + this.name + " is already in arena!");
            return false;
        }

        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.ArenaSlot);
        if (target == null) {
            Debug.Log("A free arena slot could not be found!");
            return false;
        }

        Debug.Log("FIGHT: " + this.name + " is going to arena slot " + target.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableArenaSlots, -1);
        inventory.AddItem(target);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.ModifyState("awaitOpponent", 0);

        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState("fightersInArena" + arenaId, 1);

        return true;
    }
}
