// carryDefeated
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDefeated : GAction
{
    GameObject bed;

    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(WorldStateProps.DefeatedWarriorsInArena);
        if (target == null)
            return false;

        bed = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.Bed);
        if (bed == null) {
            GWorld.Instance.GetSharedResources().AddResource(WorldStateProps.DefeatedWarriorsInArena, target);
            target = null;
            return false;
        }

        inventory.AddItem(bed);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableBeds, -1);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("awaitCasualties");
        // target.GetComponent<GAgent>().inventory.AddItem(bed);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.DefeatedWarriorsInArena, -1);
        return true;
    }
}
