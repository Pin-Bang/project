using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public static class Util
{
    public static float VectorToAngle(UnityEngine.Vector2 vector)
    {
        if (vector.x < 0)
        {
            return 360 - (Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
        }
    }
}
