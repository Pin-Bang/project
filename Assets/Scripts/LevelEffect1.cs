using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEffect1 : LevelEffect
{
    public List<GameObject> objects1 = new List<GameObject>();
    public List<GameObject> objects2 = new List<GameObject>();
    
    public override void SetValue(float value)
    {
        foreach (GameObject obj in objects1)
        {
            obj.SetActive(value < 0);
        }
        foreach(GameObject obj in objects2)
        {
            obj.SetActive(value > 0);
        }
    }
}
