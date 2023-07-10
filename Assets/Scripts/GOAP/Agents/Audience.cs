using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : GAgent
{
    new void Start()
    {
        base.Start();

        // Audience will aim to enjoy the sight of some fights to pass time
        SubGoal s1 = new SubGoal("passTimeAtArena", 1, false);
        goals.Add(s1, 1);
    }
}
