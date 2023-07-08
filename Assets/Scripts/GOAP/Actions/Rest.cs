using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : GAction
{
    // Add one of the available beds to inventory to make sure no other agent picks it up
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.Bed);
        if (target == null) {
            Debug.Log("Rest PrePerform: A free bed could not be found!");
            return false;
        }

        Debug.Log("Rest PrePerform: Booking bed " + target.name);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableBeds, -1);
        inventory.AddItem(target);
        return true;
    }

    public override bool PostPerform()
    {
        Debug.Log("Rest PostPerform");
        beliefs.RemoveState("exhausted");

        // Return bed to shared resources after usage
        inventory.RemoveItem(target);
        GWorld.Instance.GetSharedResources().AddResource(ResourceTypes.Bed, target);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableBeds, 1);

        return true;
    }
}
