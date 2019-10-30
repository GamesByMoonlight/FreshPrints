using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_horizontal_movement : MonoBehaviour
{
    //movement variables
    public float speed;
    private Rigidbody2D theRB;
    public bool moveRight;

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
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        }
        else
        {
            transform.Translate(dir.normalized * Time.deltaTime * speed);
           transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Turn"))
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
