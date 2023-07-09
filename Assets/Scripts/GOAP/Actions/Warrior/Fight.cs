using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : GAction
{
    GameObject opponent;
    bool isBattleLost = false;

    public override bool PrePerform()
    {
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

        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);

        /*WorldResources resources = GWorld.Instance.GetSharedResources();
        //.AddResource("fightersInArena" + arenaId, this.gameObject);
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.GetInstanceID());
        Queue<GameObject> fightersInArena = resources.GetResourcesOfType("fightersInArena" + arenaId);
        if (fightersInArena.Count < 2) {
            Debug.Log("Opponent is yet not ready to fight in arena " + arenaId);
            return false;
        }*/

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

    void Attack () {
        if (beliefs.GetState("defeated") != null) {
            Debug.LogWarning("FIGHT: " + this.name + " cannot fight anymore, they already lost to " + opponent.name);
            return;
        }

        bool isDeathlyBlow = Random.Range(0, 100) > 80;
    }

    public override bool PostPerform()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", false);

        Debug.LogWarning("FIGHT: " + this.name + " has fought " + opponent.name);
        bool isDeathlyBlow = Random.Range(0, 100) > 80;
        if (isDeathlyBlow) {
            Debug.LogWarning("FIGHT: " + this.name + " defeated " + opponent.name);
            anim.SetBool("isAttacking", false);
            beliefs.RemoveState("rested");
            beliefs.ModifyState("exhausted", 0);
            beliefs.ModifyState("winBattle", 1);

            WorldResources resources = GWorld.Instance.GetSharedResources();

            // Free arena slot
            GameObject currentArenaSlot = inventory.FindItemWithTag("Arena Slot");
            int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.GetInstanceID());
            resources.AddResource(ResourceTypes.ArenaSlot, currentArenaSlot);
            GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableArenaSlots, 1);
            GWorld.Instance.GetWorld().ModifyState("fightersInArena" + arenaId, -2);

            // KO opponent
            opponent.GetComponent<GAgent>().beliefs.RemoveState("rested");
            opponent.GetComponent<GAgent>().beliefs.ModifyState("defeated", 0);
            resources.AddResource(WorldStateProps.DefeatedWarriorsInArena, opponent);
            GWorld.Instance.GetWorld().ModifyState(WorldStateProps.DefeatedWarriorsInArena, 1);
        } else {
            Debug.Log("FIGHT: " + opponent.name + " avoided an attack from " + this.name);
        }

        return true;
    }
}
