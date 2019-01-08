using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventEnter : TriggerEvent
{
    [SerializeField]
    private string tag;

    private void OnTriggerEnter(Collider other)
    {
        if(tag == other.gameObject.tag)
        {
            StartCoroutine(CallTriggerEffects());
        }
    }
}
