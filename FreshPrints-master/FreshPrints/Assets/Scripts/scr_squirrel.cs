using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_squirrel : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;
    Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myColor = Color.black;
        mySpriteRenderer.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.AddForce(new Vector2(0,3), ForceMode2D.Force);
            ChangeColor();
        }
        void ChangeColor()
        {
            if(myColor==Color.black)
                myColor=Color.white;
            else
                myColor=Color.black;
            mySpriteRenderer.color = myColor;
        }
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector3 motion = new Vector3(1.5f,0,0);
        myRigidBody.velocity = motion;
    }
}
