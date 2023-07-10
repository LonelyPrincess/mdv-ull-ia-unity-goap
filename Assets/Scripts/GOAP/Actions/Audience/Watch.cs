using UnityEngine;

public class Watch : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Seat");
        if (target == null)
            return false;

        GameObject arenaPlatform = target.transform.parent.gameObject
          .transform.parent.gameObject
            .transform.GetChild(0).gameObject;
        transform.LookAt(arenaPlatform.transform);

        // Update duration so the time spent looking at the arena is not the same for everyone
        duration = Random.Range(5, 60);

        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
