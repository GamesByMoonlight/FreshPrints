using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_horizontal_movement : MonoBehaviour
{
    //movement variables
    private float speed =2.5f;
    private Rigidbody2D theRB;
    private bool moveRight;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(10,0,0);
        //When moveRight boolean is true, the enemy will move right
        if(!moveRight)
        {
            transform.Translate(-dir.normalized * Time.deltaTime * speed);
            transform.localScale = new Vector3(.5f, .5f, .5f);
            
        }
        else
        {
            transform.Translate(dir.normalized * Time.deltaTime * speed);
           transform.localScale = new Vector3(-.5f, .5f, .5f);

        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn"))
        {
            if(!moveRight)
            {
                moveRight = true;
            }
            else
            {
                moveRight = false;
            }
        }
    }
}
