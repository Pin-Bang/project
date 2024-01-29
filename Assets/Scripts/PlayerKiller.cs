using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public float deadSpeed = 0.3f;
    private bool gameEnd = false;
    private float waitTime = 1;
    private float frequency = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Killer Enabled");
        StartCoroutine(CheckSpeed());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"Player Killer: {other.transform.parent.name} Trigger Happened");

        if (other.transform.parent.name != $"{name} Collider")
        {
            Kill();
        }
    }

    IEnumerator CheckSpeed()
    {
        Vector2 lastPos = transform.position;
        yield return new WaitForSeconds(waitTime);
        while(true)
        {
            Vector2 pos = transform.position;
            if ((pos - lastPos).magnitude < deadSpeed / frequency)
            {
                Kill();
            }
            lastPos = pos;
            yield return new WaitForSeconds(1 / frequency);
        }
    }

    private void Kill()
    {
        if (gameEnd) return;

        Debug.Log($"Player Killer: Player {name} Dead");
        GetComponent<PlayerController>().SetSpeed(deadSpeed);
        Destroy(GetComponent<TrailGenerator>());
        Destroy(GameObject.Find($"{name} Collider"));
        gameEnd = true;

        GameObject.Find("Main Camera").GetComponent<CameraEffect>().KillEffect(transform.position);
    }
}
