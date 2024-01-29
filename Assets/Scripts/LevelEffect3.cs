using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEffect3 : LevelEffect
{
    public List<GameObject> objects1 = new List<GameObject>();
    public List<GameObject> objects2 = new List<GameObject>();

    public override void SetValue(float value)
    {
        if(value < 0)
        {
            value = -value;
            foreach(GameObject obj in objects1)
            {
                var slider = obj.GetComponent<SliderEffect>();
                var rotation = obj.GetComponent<RotationEffect>();
                if (slider != null)
                    slider.SetRatio(value);
                if (rotation != null)
                    rotation.SetRatio(value);
            }
        }
        else
        {
            foreach (GameObject obj in objects2)
            {
                var slider = obj.GetComponent<SliderEffect>();
                var rotation = obj.GetComponent<RotationEffect>();
                if (slider != null)
                    slider.SetRatio(value);
                if (rotation != null)
                    rotation.SetRatio(value);
            }
        }
    }
}
