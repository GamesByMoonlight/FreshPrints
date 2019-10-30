using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_vertical_movement : MonoBehaviour
{
    //movement variables
    private float speed = 2.5f;//Edit this variable to adjust enemy speed. 
    private Rigidbody2D theRB;
    private bool moveUp;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        moveUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(0,10,0);
        //When moveUp boolean is true, the enemy will move up
        if(!moveUp)
        {
            transform.Translate(-dir.normalized * Time.deltaTime * speed);
       transform.localScale = new Vector3(0.5f, .5f, .5f);
            
        }
        else
        {
            transform.Translate(dir.normalized * Time.deltaTime * speed);
            transform.localScale = new Vector3(.5f, .5f, .5f);

        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn"))
        {
            if(!moveUp)
            {
                moveUp = true;
            }
            else
            {
                moveUp = false;
            }
        }
    }
}
