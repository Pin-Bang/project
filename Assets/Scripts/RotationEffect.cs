using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEffect : MonoBehaviour
{
    public float maxAngle = 90f;

    public Quaternion initialRotation { get; private set; }
    private float currentRatio = 0f;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    public void SetRatio(float ratio)
    {
        currentRatio = ratio;
        transform.rotation = initialRotation * Quaternion.AngleAxis(maxAngle*currentRatio, Vector3.forward);
    }
}
