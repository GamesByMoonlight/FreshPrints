using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {

        transform.eulerAngles += new Vector3(0f, Time.deltaTime * 100, 0f);
    }
}
