using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrailGeneratorConfig",menuName = "Create TrailGeneratorConfig")]
public class TrailGeneratorConfig : ScriptableObject
{
    public float delayDuration = 0.1f;
    public float aliveDuration = 1;
    public float spawnWidth = 0.8f;
    public float deadWidth = 0.3f;
    public Sprite debugImage;
}
