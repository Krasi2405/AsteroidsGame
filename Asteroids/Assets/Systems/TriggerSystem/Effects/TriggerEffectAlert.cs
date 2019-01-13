using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectAlert : TriggerEffect
{
    [SerializeField]
    private string text;

    [SerializeField]
    private float duration = 0;

    public override void ActivateEffect()
    {
        if (duration > 0)
        {
            FindObjectOfType<AlertBox>().Flash(text, duration);
        }
        else
        {
            FindObjectOfType<AlertBox>().Flash(text);
        }
    }

    
    public override bool IsAsynchronous()
    {
        return true;
    }
}
