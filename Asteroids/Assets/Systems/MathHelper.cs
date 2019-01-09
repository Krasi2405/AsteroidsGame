using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathHelper
{
    public static float LinearFloatInterpolation(float current, float target, float step)
    {
        if (current < target)
        {
            current += step;
            if (current > target)
            {
                current = target;
            }
        }
        else if (current > target)
        {
            current -= step;
            if (current < target)
            {
                current = target;
            }
        }
        return current;
    }
}
