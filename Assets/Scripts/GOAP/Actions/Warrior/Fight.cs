using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : GAction
{
    public override bool PrePerform()
    {
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        if (currentArenaSlot == null) {
            Debug.Log("An assigned arena slot could not be found!");
            return false;
        }

        int arenaId = currentArenaSlot.transform.parent.gameObject.GetInstanceID();
        if (GWorld.Instance.GetWorld().GetState("fightersInArena" + arenaId) < 2) {
            Debug.Log("Opponent is yet not ready to fight in arena " + arenaId);
            return false;
        }

        // TODO: validate an opponent is available
        // currentArenaSlot.GetComponentInParent();

        /*target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.ArenaSlot);
        if (target == null) {
            Debug.Log("A free arena slot could not be found!");
            return false;
        }

        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableArenaSlots, -1);
        inventory.AddItem(target);*/

        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
