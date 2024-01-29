using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class App
{
    public const int renderFrameRate = 60;
    public const int physicsFrameRate = 50;

    [RuntimeInitializeOnLoadMethod]
    static void OnLoad()
    {
        Debug.Log("Application Load");
        Application.targetFrameRate = renderFrameRate;
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
