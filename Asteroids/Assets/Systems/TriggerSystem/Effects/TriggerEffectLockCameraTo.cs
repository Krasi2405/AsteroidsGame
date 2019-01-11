using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectLockCameraTo : TriggerEffect
{
    [SerializeField]
    private Location lockLocation;

    public override void ActivateEffect()
    {
        FindObjectOfType<FollowCamera>().LockTo(lockLocation.GetLocation());
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
