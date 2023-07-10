using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : GAgent
{
    new void Start()
    {
        base.Start();

        // Warriors must have stamina from the start
        beliefs.ModifyState("rested", 0);

        // Warriors main goal is to fight
        SubGoal s1 = new SubGoal("fight", 1, false);
        goals.Add(s1, 5);

        // Warriors need to remain at waiting zone while there are no arenas to join
        SubGoal s2 = new SubGoal("train", 1, false);
        goals.Add(s2, 1);

        // Warriors need to await treatment when knocked out
        SubGoal s3 = new SubGoal("awaitTreatment", 1, false);
        goals.Add(s3, 3);

        // Warriors need to be well rested in order to fight
        SubGoal s4 = new SubGoal("rested", 1, false);
        goals.Add(s4, 3);
    }
}
