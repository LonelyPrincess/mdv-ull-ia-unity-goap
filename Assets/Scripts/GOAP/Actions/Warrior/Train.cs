using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : GAction
{
    public override bool PrePerform()
    {
        if (beliefs.GetState("awaitOpponent") != null || beliefs.GetState("readyToFight") != null) {
            return false;
        }

        Debug.Log("FIGHT: " + this.name + " is running action " + this.actionName + beliefs.GetState("awaitOpponent") + beliefs.GetState("readyToFight"));
        return true;
    }

    public override bool PostPerform()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);
        return true;
    }
}
