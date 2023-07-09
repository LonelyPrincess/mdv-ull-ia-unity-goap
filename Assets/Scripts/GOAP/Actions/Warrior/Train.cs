using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);
        return true;
    }
}
