using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerCollisions : MonoBehaviour {

    CapsuleCollider myCollider;
    Rigidbody myRB;

    void Start()
    {
        myCollider = GetComponent<CapsuleCollider>();
        myRB = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(PlayerDie());
            myRB.velocity = Vector3.zero;
            myCollider.enabled = false;
            myRB.useGravity = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<JumpingGameCollectable>())
        {
            var collectable = col.gameObject.GetComponent<JumpingGameCollectable>();
            collectable.OnCollected();
        }
    }

    void ResetCollisions()
    {
        if(myCollider)
            myCollider.enabled = true;
        if(myRB)
            myRB.useGravity = true;
    }

    IEnumerator PlayerDie()
    {
        GameEventSystem.OnPlayerFail();  // Stops inputs, etc
        
        // Some sort of player death animation
        yield return new WaitForSeconds(2);  // Replace "2" with length of player death animation/sfx

        GameEventSystem.OnLevelReset();
    }

    void OnEnable()
    {
        GameEventSystem.LevelReset += ResetCollisions;
    }

    void OnDisable()
    {
        GameEventSystem.LevelReset -= ResetCollisions;
    }

}
