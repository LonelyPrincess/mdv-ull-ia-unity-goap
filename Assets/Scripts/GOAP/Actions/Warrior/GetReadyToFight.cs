using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyToFight : GAction
{
    public override bool PrePerform()
    {
        Debug.Log("FIGHT: " + this.name + " is running action " + this.actionName);
        Debug.Log("FIGHT: " + this.name + " is waiting for opponent? " + (beliefs.GetState("awaitOpponent") != null));

        /*string agentBeliefs = this.name + "beliefs: ";
        foreach (KeyValuePair<string, int> kvp in beliefs.GetStates())
        {
            agentBeliefs += kvp.Key + " = " + kvp.Value + ", ";
        }
        Debug.Log("FIGHT: " + agentBeliefs);*/

        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        target = currentArenaSlot;

        if (inventory.FindItemWithTag("Warrior") != null) {
            return true;
        }

        GameObject self = this.gameObject;
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

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("awaitOpponent");
        beliefs.ModifyState("readyToFight", 0);

        string agentBeliefs = this.name + "beliefs after getting ready to fight for " + this.name + ": ";
        foreach (KeyValuePair<string, int> kvp in beliefs.GetStates())
        {
            agentBeliefs += kvp.Key + " = " + kvp.Value + ", ";
        }
        Debug.Log(agentBeliefs);

        return true;
    }
}
