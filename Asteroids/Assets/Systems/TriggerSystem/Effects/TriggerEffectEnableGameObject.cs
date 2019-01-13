using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectEnableGameObject : TriggerEffect
{
    [SerializeField]
    private GameObject gameObj;

    public override void ActivateEffect()
    {
        gameObj.SetActive(true);
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
