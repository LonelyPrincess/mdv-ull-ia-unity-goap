using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : GAction
{
    // Add one of the available patients to inventory to make sure no other agent picks it up
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(WorldStateProps.WarriorsAwaitingTreatment);
        if (target == null) {
            Debug.Log("Healer couldn't find anyone to heal");
            return false;
        }

        Debug.Log("Healer will heal " + target.name);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("treatedWarriors", 1);
        GWorld.Instance.GetWorld().ModifyState("warriorsAwaitingTreatment", -1);

        // Remove patient from inventory and make them feel recovered
        inventory.RemoveItem(target);
        target.GetComponent<GAgent>().beliefs.ModifyState("isRecovering", 0);

        return true;
    }
}
