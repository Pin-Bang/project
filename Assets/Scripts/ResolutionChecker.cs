using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChecker : MonoBehaviour
{
    // Update is called once per frame
    void OnGUI()
    {
        float width = Screen.width;
        float height = Screen.height;
        float aspect = width / height;
        if (aspect < 1.77)
        {
            GUI.skin.textArea.fontSize = 60;
            GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
            GUI.TextArea(new Rect(0, 0, width, height), "Unsupported Resolution Aspect");
        }
    }
}
