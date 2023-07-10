using UnityEngine;

public class GetReadyToFight : GAction
{
    public override bool PrePerform()
    {
        GameObject currentArenaSlot = inventory.FindItemWithTag(ResourceTags.ArenaSlot);
        target = currentArenaSlot;

        if (inventory.FindItemWithTag(ResourceTags.Warrior) != null) {
            return true;
        }

        GameObject self = this.gameObject;
        int arenaId = Mathf.Abs(currentArenaSlot.transform.parent.gameObject.transform.parent.gameObject.GetInstanceID());

        WorldResources resources = GWorld.Instance.GetSharedResources();
        GameObject opponent = resources.RemoveResource(ResourceTypes.WarriorsAwaitingBattle + arenaId);
        if (opponent == null || opponent == self) {
            Debug.Log(this.name + " still has no opponent in arena " + arenaId);
            resources.AddResource(ResourceTypes.WarriorsAwaitingBattle + arenaId, self);
            return false;
        }

        Debug.Log(this.name + " had an opponent waiting in arena " + arenaId);
        inventory.AddItem(opponent);
        opponent.GetComponent<GAgent>().inventory.AddItem(self);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("awaitOpponent");
        beliefs.ModifyState("readyToFight", 0);
        return true;
    }
}
