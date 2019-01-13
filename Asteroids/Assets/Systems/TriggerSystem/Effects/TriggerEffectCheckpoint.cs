using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectCheckpoint : TriggerEffect
{
    [SerializeField]
    private int checkpointIndex;

    public override void ActivateEffect()
    {
        FindObjectOfType<CheckpointManager>().SetCheckpoint(checkpointIndex);
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
