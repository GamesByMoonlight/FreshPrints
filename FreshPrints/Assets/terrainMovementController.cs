using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainMovementController : MonoBehaviour, IPlatformController
{
    public float PlatformPosition { get; set; }

    public float min = -1.0f;
    public float max = 1.0f;

    float interpolator;
    
    void Start()
    {
        interpolator = 0f;
    }

    void Update()
    {
        interpolator += Time.deltaTime;

        PlatformPosition = Mathf.Lerp(min, max, interpolator);

        if (PlatformPosition >= max)
        {
            interpolator = 0;

            float temp = max;
            max = min;
            min = temp;
        }
    }
}
