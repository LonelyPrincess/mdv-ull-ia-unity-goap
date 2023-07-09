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
        /* GameObject self = this.gameObject;
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.GetInstanceID());
        Debug.Log("FIGHT: " + this.name + " is going to arena " + arenaId);
        GWorld.Instance.GetWorld().ModifyState("fightersInArena" + arenaId, 1);

        WorldResources resources = GWorld.Instance.GetSharedResources();
        GameObject opponent = resources.RemoveResource("fightersWaitingInArena" + arenaId);
        if (opponent == null || opponent == self) {
            Debug.Log("FIGHT: " + this.name + " still has no opponent in arena " + arenaId);
            resources.AddResource("fightersWaitingInArena" + arenaId, self);
        } else {
            Debug.Log("FIGHT: " + this.name + " had an opponent waiting in arena " + arenaId);
            inventory.AddItem(opponent);
            opponent.GetComponent<GAgent>().inventory.AddItem(self);
        } */
        beliefs.ModifyState("awaitOpponent", 0);
        return true;
    }
}
