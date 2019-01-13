using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectDisableGameObject : TriggerEffect
{
    [SerializeField]
    private GameObject gameObj;

    public override void ActivateEffect()
    {
        gameObj.SetActive(false);
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
