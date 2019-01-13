using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerEffect : MonoBehaviour
{
    public abstract void ActivateEffect();


    public virtual bool HasFinished()
    {
        if(IsAsynchronous())
        {
            return true;
        }

        throw new System.NotImplementedException(
            "You need to override HasFinished on " + name + " if it is not asynchronous!"
        );
    }

    // Vseki put kato go polzvam tui edna chast ot dushata mi izchezva
    // TODO: da dobavq abstract async i sync triggereffect classove
    public abstract bool IsAsynchronous();
}
