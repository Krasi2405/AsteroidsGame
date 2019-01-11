using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectLockCamera : TriggerEffect
{
    public override void ActivateEffect()
    {
        FindObjectOfType<FollowCamera>().LockCamera();
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
