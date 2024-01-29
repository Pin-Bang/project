using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraEffectConfig", menuName = "Create CameraEffectConfig")]
public class CameraEffectConfig : ScriptableObject
{
    // Desired duration of the shake effect
    public float shakeDuration = 0.3f;
    // A measure of magnitude for the shake. Tweak based on your preference
    public float shakeMagnitude = 0.5f;

    public float zoomDuration = 1f;

    public float zoomSize = 2f;
}
