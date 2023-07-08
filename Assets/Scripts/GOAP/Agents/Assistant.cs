using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : GAgent
{
    new void Start()
    {
        base.Start();

        // Assistants must help carry the KOed fighters to bed
        SubGoal s1 = new SubGoal("carryDefeated", 1, false);
        goals.Add(s1, 5);

        // All agents will attempt to be well rested to have enough stamina
        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 2);
        Invoke("GetTired", Random.Range(10, 20));
    }

    void GetTired()
    {
        Debug.Log("Assistant is so tired...");
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }
}
