using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSeat : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.Seat);
        if (target == null)
            return false;

        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableSeats, -1);

        return true;
    }

    public override bool PostPerform()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isJumping", true);

        int arenaId = Mathf.Abs(target.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState("audienceInArena" + arenaId, 1);
        return true;
    }
}
