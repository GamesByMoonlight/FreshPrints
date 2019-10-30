using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpResetCollider : MonoBehaviour {

    public delegate void GroundTouchEventManager();
    public delegate void CantJumpEventManager();

    public static event GroundTouchEventManager GroundTouched;
    public static event CantJumpEventManager CantJump;

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            OnGroundTouched();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            OnCantJump();
        }
    }

    void OnGroundTouched()
    {
        if (GroundTouched != null)
        {
            GroundTouched();
        }
    }

    void OnCantJump()
    {
        if (CantJump != null)
        {
            CantJump();
        }
    }
}
