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

        // Assistants need to remain at waiting zone while there are no KOed people
        SubGoal s2 = new SubGoal("awaitCasualties", 1, false);
        goals.Add(s2, 1);

        // Assistants will attempt to be well rested to have enough stamina
        SubGoal s3 = new SubGoal("rested", 1, false);
        goals.Add(s3, 2);
        Invoke("GetTired", Random.Range(30, 60));
    }

    void GetTired()
    {
        Debug.Log("Assistant is so tired...");
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(30, 60));
    }
}
