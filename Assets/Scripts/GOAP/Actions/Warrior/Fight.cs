using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : GAction
{
    GameObject opponent;
    public override bool PrePerform()
    {
        Debug.Log("FIGHT: " + this.name + " is running action " + this.actionName);
        string agentBeliefs = this.name + "beliefs before fight for " + this.name + ": ";
        foreach (KeyValuePair<string, int> kvp in beliefs.GetStates())
        {
            agentBeliefs += kvp.Key + " = " + kvp.Value + ", ";
        }
        Debug.Log(agentBeliefs);

        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        if (currentArenaSlot == null) {
            Debug.Log("FIGHT: An assigned arena slot could not be found!");
            return false;
        }

        opponent = inventory.FindItemWithTag("Warrior");
        if (opponent == null) {
            Debug.Log("FIGHT: An opponent could not be found!");
            return false;
        }

        Debug.Log("FIGHT: " + this.name + " is ready to fight with " + opponent.name);
        target = currentArenaSlot;
        transform.LookAt(opponent.transform.position);
        Debug.Log("FIGHT: " + this.name + " should look at " + opponent.name);

        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);

        InvokeRepeating("Attack", 0, 1);

        return true;
    }

    void CeaseAttack () {
        CancelInvoke("Attack");
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", false);
    }

    void Attack () {
        if (beliefs.GetState("defeated") != null) {
            Debug.LogWarning("FIGHT: " + this.name + " cannot fight anymore, they already lost to " + opponent.name);
            CeaseAttack();
            return;
        }

        bool isDeathlyBlow = Random.Range(0, 100) > 90;
        if (isDeathlyBlow) {
            Debug.LogWarning("FIGHT: " + this.name + " defeated " + opponent.name);
            beliefs.ModifyState("winBattle", 1);
            CeaseAttack();

            // Update status of opponent for them to know they've been defeated
            opponent.GetComponent<GAgent>().beliefs.ModifyState("defeated", 0);
        } else {
            Debug.Log("FIGHT: " + opponent.name + " avoided an attack from " + this.name);
        }
    }

    public override bool PostPerform()
    {
        Debug.LogWarning("FIGHT: " + this.name + " has finished fighting with " + opponent.name);
        CeaseAttack();

        WorldResources resources = GWorld.Instance.GetSharedResources();

        beliefs.RemoveState("rested");
        beliefs.RemoveState("readyToFight");
        inventory.RemoveItem(opponent);

        string agentBeliefs = this.name + "beliefs after fight for " + this.name + ": ";
        foreach (KeyValuePair<string, int> kvp in beliefs.GetStates())
        {
            agentBeliefs += kvp.Key + " = " + kvp.Value + ", ";
        }

        Debug.Log(agentBeliefs);

        // If battle was lost, add warrior to defeated pending to be picked up
        if (beliefs.GetState("defeated") != null) {
            resources.AddResource(WorldStateProps.DefeatedWarriorsInArena, this.gameObject);
            GWorld.Instance.GetWorld().ModifyState(WorldStateProps.DefeatedWarriorsInArena, 1);
            return true;
        }

        // If battle was won or ended up in draw, free arena slot
        beliefs.ModifyState("exhausted", 0);
        GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.GetInstanceID());
        inventory.RemoveItem(currentArenaSlot);
        resources.AddResource(ResourceTypes.ArenaSlot, currentArenaSlot);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableArenaSlots, 1);
        GWorld.Instance.GetWorld().ModifyState("fightersInArena" + arenaId, -1);

        return true;
    }
}
