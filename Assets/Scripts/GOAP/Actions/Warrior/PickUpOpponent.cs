using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupOpponent : GAction
{
    public override bool PrePerform()
    {
        /*Debug.Log("FIGHT: " + this.name + " is running action " + this.actionName);

        WorldResources resources = GWorld.Instance.GetSharedResources();
        GameObject opponent = resources.RemoveResource("unmatchedWarriors");

        if (inventory.FindItemWithTag("Warrior") != null) {
            beliefs.RemoveState("awaitOpponent");
            return true;
        }

        GameObject self = this.gameObject;
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.GetInstanceID());

        WorldResources resources = GWorld.Instance.GetSharedResources();
        GameObject opponent = resources.RemoveResource("fightersWaitingInArena" + arenaId);
        if (opponent == null || opponent == self) {
            Debug.Log("FIGHT: " + this.name + " still has no opponent in arena " + arenaId);
            resources.AddResource("fightersWaitingInArena" + arenaId, self);
            return false;
        }

        Debug.Log("FIGHT: " + this.name + " had an opponent waiting in arena " + arenaId);
        inventory.AddItem(opponent);
        opponent.GetComponent<GAgent>().inventory.AddItem(self);

        beliefs.RemoveState("awaitOpponent");*/
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
