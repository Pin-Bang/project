using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    private static bool created = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(created)
        {
            DestroyImmediate(gameObject);
        }
        created = true;
    }

    void Start()
    {
        Debug.Log($"Persistent Manager Enabled");
        GameObject.DontDestroyOnLoad( this );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
