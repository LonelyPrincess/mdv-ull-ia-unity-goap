using UnityEngine;

public class GoToArena : GAction
{
    public override bool PrePerform()
    {
        GameObject currentArenaSlot = inventory.FindItemWithTag(ResourceTags.ArenaSlot);
        if (currentArenaSlot != null) {
            Debug.Log(this.name + " is already in arena!");
            return false;
        }

        target = GWorld.Instance.GetSharedResources().RemoveResource(ResourceTypes.AvailableArenaSlots);
        if (target == null) {
            Debug.Log("A free arena slot could not be found!");
            return false;
        }

        Debug.Log(this.name + " is going to arena slot " + target.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableArenaSlots, -1);
        inventory.AddItem(target);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.ModifyState("awaitOpponent", 0);

        GameObject currentArenaSlot = inventory.FindItemWithTag(ResourceTags.ArenaSlot);
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());
        GWorld.Instance.GetWorld().ModifyState(ResourceTypes.ActiveWarriorsInArena + arenaId, 1);

        return true;
    }
}
