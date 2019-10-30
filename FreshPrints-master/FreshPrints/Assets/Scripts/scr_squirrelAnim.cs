using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_squirrelAnim : MonoBehaviour
{
    public Animator anim;
    Rigidbody2D playerRigidbody;
    public bool isFlying;
    public float playerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpeed = playerRigidbody.velocity.x;
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
    }

    void SetSpeed()
    {
        playerSpeed = playerRigidbody.velocity.x;
        anim.SetFloat("mySpeed", playerSpeed);
    }
}
