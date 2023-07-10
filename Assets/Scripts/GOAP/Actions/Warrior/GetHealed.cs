public class GetHealed : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag(ResourceTags.Bed);
        if (target == null) {
            return false;
        }
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("awaitTreatment");
        beliefs.RemoveState("isRecovering");

        // Return bed to shared resources after usage
        inventory.RemoveItem(target);
        GWorld.Instance.GetSharedResources().AddResource(ResourceTypes.AvailableBeds, target);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableBeds, 1);

        return true;
    }
}
