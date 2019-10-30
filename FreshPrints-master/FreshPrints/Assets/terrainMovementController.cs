using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Demo IPlatformController for how terrain movement can be controlled.
/// This just goes back and forth between min and max
/// 
/// See Test_Terrain
/// </summary>
public class terrainMovementController : MonoBehaviour, IPlatformController
{
    public float PlatformPosition { get; set; }

    public float min = -1.0f;
    public float max = 1.0f;

    float interpolator;

    bool increasing = false;

    void Start()
    {
        interpolator = 0f;

    }

    void Update()
    {
        if (increasing)
        {
            interpolator += Time.deltaTime;

            if (PlatformPosition >= max)
            {
                increasing = false;
            }
        } else
        {
            interpolator -= Time.deltaTime;

            if (PlatformPosition <= min)
            {
                increasing = true;
            }
        }
            

        PlatformPosition = Mathf.Lerp(min, max, interpolator);
    }
}
