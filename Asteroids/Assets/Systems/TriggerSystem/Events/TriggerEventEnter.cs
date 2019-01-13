using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventEnter : TriggerEvent
{
    [SerializeField]
    private string tag;

    private bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!hasBeenTriggered && tag == other.gameObject.tag)
        {
            StartCoroutine(CallTriggerEffects());
            hasBeenTriggered = true;
        }
    }
}
