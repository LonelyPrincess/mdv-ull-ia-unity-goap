using UnityEngine;

public class Train : GAction
{
    public override bool PrePerform()
    {
        if (beliefs.GetState("awaitOpponent") != null || beliefs.GetState("readyToFight") != null) {
            return false;
        }

        return true;
    }

    public override bool PostPerform()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);
        return true;
    }
}
