using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    public override bool PrePerform()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isJumping", true);

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
