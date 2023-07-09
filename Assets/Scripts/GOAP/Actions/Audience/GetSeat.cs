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
        GameObject arena = target.transform.parent.gameObject.transform.parent.gameObject;
        int arenaId = Mathf.Abs(arena.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState("audienceInArena" + arenaId, 1);

        transform.LookAt(arena.transform.GetChild(0).gameObject.transform);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(arena.transform.GetChild(0).gameObject.transform.position), 2.0f * Time.deltaTime);

        /* Vector3 relativePos = arena.transform.GetChild(0).gameObject.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, new Vector3(0,1,0));
        transform.rotation = rotation * Quaternion.Euler(0, 90, 0); */

        return true;
    }
}
