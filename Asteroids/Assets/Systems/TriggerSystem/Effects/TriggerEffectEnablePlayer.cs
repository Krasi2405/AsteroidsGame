using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectEnablePlayer : TriggerEffect
{
    public override void ActivateEffect()
    {
        FindObjectOfType<PlayerController>().enabled = true;
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
