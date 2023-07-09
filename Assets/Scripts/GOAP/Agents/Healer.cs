using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : GAgent
{
    new void Start()
    {
        base.Start();

        // Healers must help fighters awaiting treatment
        SubGoal s1 = new SubGoal("healWarrior", 1, false);
        goals.Add(s1, 5);

        // Healers need to remain at waiting zone while there are no KOed people
        SubGoal s2 = new SubGoal("awaitPatients", 1, false);
        goals.Add(s2, 1);

        // All agents will attempt to be well rested to have enough stamina
        SubGoal s3 = new SubGoal("rested", 1, false);
        goals.Add(s3, 2);
        Invoke("GetTired", Random.Range(10, 20));
    }

    void GetTired()
    {
        Debug.Log("Healer is so tired...");
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }
}
