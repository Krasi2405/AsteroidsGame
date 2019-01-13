using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectWinGame : TriggerEffect
{
    public override void ActivateEffect()
    {
        FindObjectOfType<LevelStateManager>().Win();
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
