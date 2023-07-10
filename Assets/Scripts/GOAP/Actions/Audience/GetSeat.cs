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
        return true;
    }
}
