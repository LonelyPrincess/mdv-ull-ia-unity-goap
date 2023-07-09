using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : GAgent
{
    new void Start()
    {
        base.Start();

        // Audience will aim to enjoy the sight of some fights
        SubGoal s1 = new SubGoal("enjoyFight", 1, false);
        goals.Add(s1, 5);

        // Audience may want to return home after a while
        SubGoal s2 = new SubGoal("goHome", 1, false);
        goals.Add(s2, 1);
    }
}
