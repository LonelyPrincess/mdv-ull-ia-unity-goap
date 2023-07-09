using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyToFight : GAction
{
    public override bool PrePerform()
    {
        Debug.Log("FIGHT: " + this.name + " is running action " + this.actionName);

        if (inventory.FindItemWithTag("Warrior") != null) {
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
            // beliefs.ModifyState("awaitOpponent", 0);
            return false;
        }

        Debug.Log("FIGHT: " + this.name + " had an opponent waiting in arena " + arenaId);
        inventory.AddItem(opponent);
        opponent.GetComponent<GAgent>().inventory.AddItem(self);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("awaitOpponent");
        return true;
    }
}
