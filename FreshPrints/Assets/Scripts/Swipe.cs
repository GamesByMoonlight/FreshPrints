using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool isDragging;
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    public Vector2 startTouch, swipeDelta;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }else  if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }

        /// mobile

        if (Input.touches.Length >0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                tap = true;
                startTouch = Input.touches[0].position;

            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }


        }


        //calc distaance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if(Input.touches.Length> 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }


        }
        
        if(swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if( Mathf.Abs(x)> Mathf.Abs(y) )
            {
                //left or right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }

            }
            else
            {
                // up or down
                if( y <0 )
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }

            }


            Reset();

        }


    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;

    }




}
