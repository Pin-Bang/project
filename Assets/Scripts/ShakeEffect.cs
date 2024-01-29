using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public bool alwaysEnable = false;
    public float shakeMagnitude = 0.05f;
    public float shakeDuration = 0.3f;
    private bool enable = true;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!enable) return;
        StartCoroutine(Shake());
    }

    private void Update()
    {
        if(enable && alwaysEnable)
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        enable = false;
        Vector3 initialPosition = transform.position;
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        while (true)
        {
            if (stopwatch.ElapsedMilliseconds > shakeDuration * 1000)
            {
                break;
            }
            Vector2 random = Random.insideUnitCircle.normalized;
            transform.position = initialPosition + new Vector3(random.x, random.y, 0) * shakeMagnitude;
            yield return new WaitForNextFrameUnit();
        }
        transform.position = initialPosition;
        enable = true;
    }
}
