using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour {

    Transform playerTransform;
    Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        playerTransform = FindObjectOfType<scr_squirrel>().GetComponent<Transform>();

        cameraOffset = transform.position - playerTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((playerTransform.position.x + cameraOffset.x), 0, 0);
	}
}
