using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectUnlockCamera : TriggerEffect
{
    public override void ActivateEffect()
    {
        FindObjectOfType<FollowCamera>().UnlockCamera();
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
