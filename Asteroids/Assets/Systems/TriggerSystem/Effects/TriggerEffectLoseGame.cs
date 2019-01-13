using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectLoseGame : TriggerEffect
{
    public override void ActivateEffect()
    {
        FindObjectOfType<LevelStateManager>().Lose();
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
