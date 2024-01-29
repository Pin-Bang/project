using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerControllerConfig config;
    public float spawnAngle = 0f;
    private float speed;
    private float angularSpeed = 0f;
    private Rigidbody2D rigidbodyComponent;
    private Vector2 extraVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        speed = config.defaultSpeed;
        rigidbodyComponent.SetRotation(spawnAngle);
    }


    void UpdateRigidbody()
    {
        rigidbodyComponent.velocity = transform.up * speed;
        rigidbodyComponent.angularVelocity = angularSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        // Debug.Log($"Player Controller: {name} Speed Set to {newSpeed}");
        speed = newSpeed;
        UpdateRigidbody();
    }

    public void SetSpeedDelta(float newSpeedDelta)
    {
        SetSpeed(speed + newSpeedDelta);
    }

    public void SetAngularSpeed(float newAngularSpeed)
    {
        // Debug.Log($"Player Controller: {name} Angular Speed Set to {newAngularSpeed}");
        angularSpeed = newAngularSpeed * config.defaultAngularSensitivity;
        UpdateRigidbody();
    }

    public void SetAngularSpeedDelta(float newAngularSpeedDelta)
    {
        SetAngularSpeed(angularSpeed + newAngularSpeedDelta);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contactPoint = other.contacts[0];

        Vector2 newForward = Vector2.Reflect(transform.up, contactPoint.normal);
        rigidbodyComponent.SetRotation(-Util.VectorToAngle(newForward));
        // Debug.Log($"Player Controller: {name} Collsion Happened {newForward}");

        UpdateRigidbody();
    }
}
