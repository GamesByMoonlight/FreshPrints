using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerRun : MonoBehaviour {

    [SerializeField]
    float PlayerSpeed;

    public float currentSpeed;

    private Vector3 startLocation;
    private Rigidbody myRB;

    void Awake()
    {
        startLocation = transform.position;
    }

	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * currentSpeed;	
	}

    void ResetPosition()
    {
        transform.position = startLocation;
    }

    void BeginMoving()
    {
        currentSpeed = PlayerSpeed;
    }

    void StopMoving()
    {
        currentSpeed = 0;
    }

    #region GameEventSystem subscription
    void OnEnable()
    {
        GameEventSystem.LevelReset += ResetPosition;
        GameEventSystem.BeginPlay += BeginMoving;
        GameEventSystem.PlayerFail += StopMoving;
    }

    void OnDisable()
    {
        GameEventSystem.LevelReset -= ResetPosition;
        GameEventSystem.BeginPlay -= BeginMoving;
        GameEventSystem.PlayerFail -= StopMoving;
    }
    #endregion  
}

