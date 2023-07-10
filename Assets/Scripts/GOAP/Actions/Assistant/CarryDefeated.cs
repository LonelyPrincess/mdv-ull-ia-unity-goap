public class CarryDefeated : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag(ResourceTags.Bed);
        if (target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("pickupDefeated");
        inventory.RemoveItem(target);
        return true;
    }
}
