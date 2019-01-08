using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerEvent : MonoBehaviour
{
    TriggerEffect[] triggerEffects;


    protected IEnumerator CallTriggerEffects()
    {
        triggerEffects = GetComponents<TriggerEffect>();
        foreach(TriggerEffect triggerEffect in triggerEffects)
        {
            triggerEffect.ActivateEffect();
            while (!triggerEffect.HasFinished())
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
