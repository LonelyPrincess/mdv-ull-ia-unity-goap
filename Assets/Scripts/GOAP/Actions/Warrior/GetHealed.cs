using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealed : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag(ResourceTypes.Bed);
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
        GWorld.Instance.GetSharedResources().AddResource(ResourceTypes.Bed, target);
        GWorld.Instance.GetWorld().ModifyState(WorldStateProps.AvailableBeds, 1);

        return true;
    }
}
