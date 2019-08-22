using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2D : MonoBehaviour {

    [SerializeField]
    float JumpPower;
    [SerializeField]
    int PossibleJumpSteps;

    int LandingBuffer;
    int JumpStepsRemaining;

    bool canJump;
    bool areJumping;
    bool readInput;

    Rigidbody myBody;
    Animator myAnim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myAnim = GetComponentInChildren<Animator>();

        JumpStepsRemaining = PossibleJumpSteps;
        canJump = false;
        areJumping = false;
        readInput = false;

    }


	// Update is called once per frame
	void Update () {

        if (readInput)
        {
            if (Input.GetButtonUp("Jump"))
            {
                JumpStepsRemaining = 0;
            }

            if (Input.GetButton("Jump") && LandingBuffer == 2 && (canJump | areJumping))
            {
                if (canJump)
                    myAnim.SetTrigger("Jump");

                areJumping = true;
                myBody.velocity += Vector3.up * JumpPower * Mathf.Min(JumpStepsRemaining, 1);
                JumpStepsRemaining = Mathf.Max(JumpStepsRemaining - 1, 0);
                myAnim.SetBool("Airborne", true);
            }

            myAnim.SetFloat("Velocity", myBody.velocity.y);
            LandingBuffer = Mathf.Min(LandingBuffer + 1, 2);
        }


    }


    void ResetJump()
    {
        myAnim.ResetTrigger("Jump");
        myAnim.SetBool("Airborne", false);

        areJumping = false;
        canJump = true;
        JumpStepsRemaining = PossibleJumpSteps;
        LandingBuffer = 0;
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

    void AnimatePlayerResults(bool didIWin)
    {
        readInput = false;

        StartCoroutine(FinalAnimation(didIWin));
    }

    IEnumerator FinalAnimation(bool didIWin)
    {
        yield return new WaitForSeconds(1f);

        GameEventSystem.OnPlayerFail();  // This causes the player to stop moving

        if (didIWin)
        {
            myAnim.SetTrigger("Victory");
        }
        else
        {
            myAnim.SetTrigger("Defeat");
        }
    }

    void OnEnable()
    {
        JumpResetCollider.GroundTouched += ResetJump;
        JumpResetCollider.CantJump += CancelJump;
        GameEventSystem.BeginPlay += AllowInput;
        GameEventSystem.PlayerFail += PauseInput;
        GameEventSystem.EndLevel += AnimatePlayerResults;
        GameEventSystem.LevelReset += ResetPlayer;
        
    }

    void OnDisable()
    {
        JumpResetCollider.GroundTouched -= ResetJump;
        JumpResetCollider.CantJump -= CancelJump;
        GameEventSystem.BeginPlay -= AllowInput;
        GameEventSystem.PlayerFail -= PauseInput;
        GameEventSystem.EndLevel -= AnimatePlayerResults;
        GameEventSystem.LevelReset -= ResetPlayer;
    }
}
