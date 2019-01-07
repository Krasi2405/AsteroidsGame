using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RotationHelper
{
    public static float IncrementalDegreeRotation(float degrees, float target, float frame_step)
    {
        if (degrees > target)
        {
            if (degrees - target >= 180)
            {
                degrees += frame_step;
            }
            else
            {
                degrees -= frame_step;
            }
            if (degrees < target)
            {
                degrees = target;
            }
        }
        else if (degrees < target)
        {
            if (target - degrees >= 180)
            {
                degrees -= frame_step;
            }
            else
            {
                degrees += frame_step;
            }

            if (degrees > target)
            {
                degrees = target;
            }
        }
        return degrees;
    }
}
