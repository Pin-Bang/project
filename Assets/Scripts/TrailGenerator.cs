using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailGenerator : MonoBehaviour
{
    public TrailGeneratorConfig config;
    public Material trailMaterial;

    private TrailRenderer trailRender;
    private GameObject colliderGroup;
    private GameObject[] colliderPool;

    private int poolSize;
    private int poolIndex = 0;

    IEnumerator DelayGameObject(GameObject go)
    {
        go.SetActive(false);
        yield return new WaitForSeconds(config.delayDuration);
        go.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Trail Generateor Enabled");

        trailRender = gameObject.AddComponent<TrailRenderer>();
        trailRender.material = trailMaterial;
        trailRender.startWidth = config.spawnWidth;
        trailRender.endWidth = config.deadWidth;
        trailRender.time = config.aliveDuration;
        trailRender.sortingOrder = -1;

        colliderGroup = new GameObject($"{name} Collider");
        colliderGroup.transform.localScale = transform.lossyScale;

        poolSize = Mathf.FloorToInt(config.aliveDuration * App.physicsFrameRate);
        colliderPool = new GameObject[poolSize];
        
        for (int i=0; i<poolSize; i++)
        {
            GameObject collider = new GameObject($"{name} Collider {i}");
            collider.SetActive(false);
            collider.transform.SetParent(colliderGroup.transform);
            collider.transform.position = transform.position;
            collider.transform.rotation = transform.rotation;
            collider.transform.localScale = Vector3.one;
            var colliderComponent = collider.AddComponent<CircleCollider2D>();
            colliderComponent.isTrigger = true;

            if(config.debugImage !=null)
                collider.AddComponent<SpriteRenderer>().sprite = config.debugImage;

            colliderPool[i] = collider;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        colliderPool[poolIndex].transform.position = transform.position;
        colliderPool[poolIndex].transform.rotation = transform.rotation;
        StartCoroutine(DelayGameObject(colliderPool[poolIndex]));

        poolIndex++;
        if (poolIndex >= poolSize)
            poolIndex = 0;
    }
}
