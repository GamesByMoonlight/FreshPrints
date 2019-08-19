using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float playerMoveSpeed = 4f;


    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(999, 0, 0);
        transform.Translate(dir.normalized * playerMoveSpeed * Time.deltaTime, Space.World);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collisionenter");

    //    Debug.Log(gameObject.name);

    //    if(collision.collider.IsTouching(collision.otherCollider))
    //    {
    //        Debug.Log("here");
    //        rotateUP();
    //    }


    //}


    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("collisionExit");
    //    rotateForward();
    //}


    //void rotateUP()
    //{
    //    Debug.Log("UP");
    //    transform.Rotate(0, 0, 90);
    //}

    //void rotateForward()
    //{
    //    Debug.Log("forward");
    //    transform.Rotate(0, 0, 0);
    //}


}
