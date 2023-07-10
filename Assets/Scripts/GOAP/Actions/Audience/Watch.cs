using System.Collections;
using System.Collections.Generic;
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

        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
