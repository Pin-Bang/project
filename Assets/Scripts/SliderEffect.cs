using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEffect : MonoBehaviour
{
    public float maxLength = 2f;

    public Vector3 initialPosition { get; private set; }
    private float currentRatio = 0f;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void SetRatio(float ratio)
    {
        currentRatio = ratio;
        transform.position = initialPosition + transform.up * currentRatio * maxLength;
    }
}
