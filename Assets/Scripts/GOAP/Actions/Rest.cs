using UnityEngine;

public class Rest : GAction
{
    // Add one of the available beds to inventory to make sure no other agent picks it up
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.AvailableBeds);
        if (target == null) {
            Debug.Log("A free bed could not be found!");
            return false;
        }

        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableBeds, -1);
        inventory.AddItem(target);
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("exhausted");

        // Return bed to shared resources after usage
        inventory.RemoveItem(target);
        GWorld.Instance.GetSharedResources().AddResource(ResourceTypes.AvailableBeds, target);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableBeds, 1);

        return true;
    }
}
