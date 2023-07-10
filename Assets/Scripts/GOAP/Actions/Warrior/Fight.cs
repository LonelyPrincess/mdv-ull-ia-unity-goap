using System.Collections.Generic;
using UnityEngine;

public class Fight : GAction
{
    GameObject opponent;
    public override bool PrePerform()
    {
        GameObject currentArenaSlot = inventory.FindItemWithTag(ResourceTags.ArenaSlot);
        if (currentArenaSlot == null) {
            Debug.Log("An assigned arena slot could not be found!");
            return false;
        }

        opponent = inventory.FindItemWithTag(ResourceTags.Warrior);
        if (opponent == null) {
            Debug.Log("An opponent could not be found!");
            return false;
        }

        Debug.Log(this.name + " is ready to fight with " + opponent.name + "!");
        target = currentArenaSlot;
        transform.LookAt(opponent.transform);

        // Trigger attack animation
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);
        InvokeRepeating("Attack", 0, 1);

        return true;
    }

    void CeaseAttack () {
        CancelInvoke("Attack");
    }

    void Attack () {
        if (beliefs.GetState("defeated") != null) {
            Debug.LogWarning(this.name + " cannot fight anymore, they already lost to " + opponent.name);
            CeaseAttack();
            return;
        }

        bool isDeathlyBlow = Random.Range(0, 100) > 90;
        if (isDeathlyBlow) {
            Debug.LogWarning(this.name + " defeated " + opponent.name);
            beliefs.ModifyState("winBattle", 1);
            CeaseAttack();

            // Update status of opponent for them to know they've been defeated
            opponent.GetComponent<GAgent>().beliefs.ModifyState("defeated", 0);
        } else {
            Debug.Log(opponent.name + " avoided an attack from " + this.name);
        }
    }

    public override bool PostPerform()
    {
        Debug.LogWarning(this.name + " has finished fighting with " + opponent.name);

        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", false);

        WorldResources resources = GWorld.Instance.GetSharedResources();

        beliefs.RemoveState("rested");
        beliefs.RemoveState("readyToFight");
        inventory.RemoveItem(opponent);

        // If battle was lost, add warrior to defeated pending to be picked up
        if (beliefs.GetState("defeated") != null) {
            resources.AddResource(ResourceTypes.DefeatedWarriorsInArena, this.gameObject);
            GWorld.Instance.GetWorld().ModifyState(ResourceTypes.DefeatedWarriorsInArena, 1);
            return true;
        }

        // If battle was won or ended up in draw, free arena slot
        GameObject currentArenaSlot = inventory.FindItemWithTag(ResourceTags.ArenaSlot);
        inventory.RemoveItem(currentArenaSlot);
        resources.AddResource(ResourceTypes.AvailableArenaSlots, currentArenaSlot);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableArenaSlots, 1);

        // Feel tired after fight
        beliefs.ModifyState("exhausted", 0);
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.ActiveWarriorsInArena + arenaId, -1);

        // Increase counter of witnessed fights for audience currently in arena
        GameObject audience;
        while ((audience = resources.RemoveResource(ResourceTypes.AudienceInArena + arenaId)) != null) {
            audience.GetComponent<GAgent>().beliefs.ModifyState("witnessedFights", 1);
        };

        return true;
    }
}
