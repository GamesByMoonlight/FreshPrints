using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour {

    Transform playerTransform;
    Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        playerTransform = FindObjectOfType<GameController2D>().GetComponent<Transform>();

        cameraOffset = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTransform.position + cameraOffset;
	}
}
