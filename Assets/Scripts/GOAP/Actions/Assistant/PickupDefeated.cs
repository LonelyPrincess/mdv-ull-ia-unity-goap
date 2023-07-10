using UnityEngine;

public class PickupDefeated : GAction
{
    GameObject bed;

    public override bool PrePerform()
    {
        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.DefeatedWarriorsInArena);
        if (target == null)
            return false;

        bed = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.AvailableBeds);
        if (bed == null) {
            GWorld.Instance.GetSharedResources().AddResource(ResourceTypes.DefeatedWarriorsInArena, target);
            target = null;
            return false;
        }

        inventory.AddItem(bed);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableBeds, -1);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("awaitCasualties");

        // Let the warrior know which bed was assigned to him
        target.GetComponent<GAgent>().inventory.AddItem(bed);
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.DefeatedWarriorsInArena, -1);
        return true;
    }
}
