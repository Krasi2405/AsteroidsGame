using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectDisablePlayer : TriggerEffect
{
    public override void ActivateEffect()
    {
        FindObjectOfType<PlayerController>().enabled = false;
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
