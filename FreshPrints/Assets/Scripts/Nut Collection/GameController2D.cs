using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2D : MonoBehaviour {

    
    int LandingBuffer;

    bool canJump;
    bool areJumping;
    bool readInput;

    Rigidbody2D myBody;
    Animator myAnim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponentInChildren<Animator>();
        canJump = false;
        areJumping = false;
        readInput = false;

    }


	// Update is called once per frame
	void Update () {

        if (readInput)
        {
            if (Input.GetButton("Jump") && LandingBuffer == 2 && (canJump | areJumping))
            {
                if (canJump)
                    myAnim.SetTrigger("Jump");

                areJumping = true;
                myAnim.SetBool("Airborne", true);
            }

            myAnim.SetFloat("Velocity", myBody.velocity.y);
            LandingBuffer = Mathf.Min(LandingBuffer + 1, 2);
        }


    }


    void CancelJump()
    {
        canJump = false;
        myAnim.SetBool("Airborne", true);
    }

    void AllowInput()
    {
        readInput = true;
    }

    public void PauseInput()
    {
        readInput = false;
    }

    void ResetPlayer()
    {
        myBody.velocity = Vector3.zero;
        myAnim.SetBool("Airborne", false);
        myAnim.ResetTrigger("Jump");
        myAnim.ResetTrigger("Defeat");
        myAnim.ResetTrigger("Victory");
        myAnim.Play("Running");
    }

    void EndLevel(int level, int acornCount)
    {
        
    }

    void OnEnable()
    {
        GameEventSystem.BeginPlay += AllowInput;
        GameEventSystem.EndLevel += EndLevel;
        GameEventSystem.LevelReset += ResetPlayer;
        
    }

    void OnDisable()
    {
        GameEventSystem.BeginPlay -= AllowInput;
        GameEventSystem.EndLevel -= EndLevel;
        GameEventSystem.LevelReset -= ResetPlayer;
    }
}
