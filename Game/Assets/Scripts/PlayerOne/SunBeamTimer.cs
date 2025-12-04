using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SunBeamTimer : MonoBehaviour
{
    public float timeTillDestory;

    public Vector3 targetScale = new Vector3(8f, 0.5f, 0f); // final size
    public float speed = 1f; // growth speed

    private Vector3 initialPosition;

    void Update()
    {

        // Smoothly interpolate from current scale to target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
        Destroy(gameObject, timeTillDestory);
    }

    void Start()
    {
        //transform.localScale = new Vector3(8f, .5f, 0f);
    }
    
}
