using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public CameraEffectConfig config;

    private Camera cameraComponent;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
    }

    public void KillEffect(Vector3 position)
    {
        Debug.Log("Camera Effect: KillEffect");
        transform.position = new Vector3(position.x, position.y, transform.position.z);
        cameraComponent.orthographicSize = config.zoomSize;
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 initialPosition = transform.position;
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        while (true)
        {
            if (stopwatch.ElapsedMilliseconds > config.shakeDuration * 1000)
            {
                transform.position = initialPosition;
                break;
            }

            Vector2 random = Random.insideUnitCircle.normalized;
            transform.position = initialPosition + new Vector3(random.x,random.y,0) * config.shakeMagnitude;
            yield return new WaitForNextFrameUnit();
        }
    }
}
