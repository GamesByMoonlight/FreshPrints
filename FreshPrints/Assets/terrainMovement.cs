using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainMovement : MonoBehaviour
{
    private IPlatformController CCC;
    private float initialY, transformedY;

    void Start() {

        try
        {
            CCC = GetComponentInParent<IPlatformController>();
        }
        catch
        {
            Debug.LogError("Parent object of " + this + " must have IPlatformController interface");
        }

        initialY = transform.localPosition.y;
        transformedY = -initialY;
    }

    void Update()
    {
        Debug.Log(CCC.PlatformPosition);
        float interpolator = Mathf.Clamp(((CCC.PlatformPosition + 1f) / 2f), 0f, 1f);
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(initialY, transformedY, interpolator), transform.localPosition.z);
    }


}

interface IPlatformController
{
    float PlatformPosition { get; set; }
}