using UnityEngine;

public class GoHome : GAction
{
    public override bool PrePerform()
    {
        // Return bench to shared resources before going home
        GameObject seat = inventory.FindItemWithTag(ResourceTags.Seat);
        if (seat != null) {
            inventory.RemoveItem(seat);
            WorldResources resources = GWorld.Instance.GetSharedResources();
            resources.AddResource(ResourceTypes.AvailableSeats, seat);
            GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AvailableSeats, +1);

            int arenaId = Mathf.Abs(seat.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());
            GWorld.Instance.GetWorld().ModifyState(ResourceTypes.AudienceInArena + arenaId, -1);
        }

        // Update duration so the time they spend at home is not the same for everyone
        duration = Random.Range(0, 60);

        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
