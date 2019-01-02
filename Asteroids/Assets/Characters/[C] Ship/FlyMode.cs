using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyMode : MonoBehaviour
{
    [SerializeField]
    private string animationTriggerName;

    public string GetAnimationTriggerName()
    {
        return animationTriggerName;
    }

    public abstract void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation);
}
