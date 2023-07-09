using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    public override bool PrePerform()
    {
        /* if (beliefs.GetState("sawFight") == null) {
            Debug.Log(this.name + " still hasn't seen a fight to the end, so cannot return home");
            return false;
        } */

        // Return bench to shared resources before going home
        GameObject bench = inventory.FindItemWithTag("Bench");
        if (bench != null) {
            inventory.RemoveItem(bench);
            WorldResources resources = GWorld.Instance.GetSharedResources();
            resources.AddResource(ResourceTypes.Seat, bench);
            GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableSeats, +1);

            int arenaId = Mathf.Abs(bench.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());
            GWorld.Instance.GetWorld().ModifyState("audienceInArena" + arenaId, -1);
        }

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("sawFight");
        return true;
    }
}
