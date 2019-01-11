using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectSetPlayareaHeight : TriggerEffect
{
    [SerializeField]
    private float playAreaHeight;

    public override void ActivateEffect()
    {
        FindObjectOfType<FollowCamera>().SetPlayAreaHeight(playAreaHeight);
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
