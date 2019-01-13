using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventStart : TriggerEvent
{
    void Start()
    {
        StartCoroutine(CallTriggerEffects());
    }
}
