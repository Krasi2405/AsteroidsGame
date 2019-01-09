using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectZoomTo : TriggerEffect
{
    [SerializeField]
    private float zoom;

    public override void ActivateEffect()
    {
        Debug.Log("Trigger zoom to!");
        FindObjectOfType<FollowCamera>().ChangeZoom(zoom);
    }

    public override bool HasFinished()
    {
        if(FindObjectOfType<FollowCamera>().transform.position.y == zoom)
        {
            return true;
        }
        return false;
    }

    public override bool IsAsynchronous()
    {
        return false;
    }
}
