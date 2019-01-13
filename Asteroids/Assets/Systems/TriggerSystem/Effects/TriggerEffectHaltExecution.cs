using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectHaltExecution : TriggerEffect
{
    [SerializeField]
    private float haltExecutionTime = 1f;

    private bool timeHasPassed = false;

    public override void ActivateEffect()
    {
        StartCoroutine(StopExecutionTime());
    }

    public override bool IsAsynchronous()
    {
        return false;
    }

    public override bool HasFinished()
    {
        return timeHasPassed;
    }

    private IEnumerator StopExecutionTime()
    {
        yield return new WaitForSeconds(haltExecutionTime);
        timeHasPassed = true;
    }
}
