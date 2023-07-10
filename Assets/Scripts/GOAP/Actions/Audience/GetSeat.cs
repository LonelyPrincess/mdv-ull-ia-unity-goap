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
        return true;
    }
}
