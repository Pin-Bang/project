using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEffect : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public float deltaLength = 0.1f;
    public float radius = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        foreach (GameObject obj in objects)
        {
            Vector3 delta3d = transform.position - obj.transform.position;
            Vector2 delta = new Vector2(delta3d.x, delta3d.y);
            float length = delta.magnitude;
            // Debug.Log($"{obj.name}:{length}");
            if(length<radius)
            {
                Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
                rigidbody.position += delta.normalized * deltaLength;
            }
        }
    }
}
