using UnityEngine;

public class GetSeat : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.AvailableSeats);
        if (target == null)
            return false;

        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableSeats, -1);

        return true;
    }

    public override bool PostPerform()
    {
        int arenaId = Mathf.Abs(target.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AudienceInArena + arenaId, 1);

        return true;
    }
}
