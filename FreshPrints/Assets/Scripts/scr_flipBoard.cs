using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_flipBoard : MonoBehaviour
{
    int boardPos;
    float myScaleY;
    bool flipping;

    // Start is called before the first frame update
    void Start()
    {
        boardPos = 1;
        myScaleY = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Flip();

        if(flipping == true)
        {
            if(boardPos == 1)
            {
                if(myScaleY >= -1.25f)
                    {
                        Vector3 newScale = new Vector3(1.25f, myScaleY ,1.25f);
                        myScaleY -= 0.05f;
                        transform.localScale = newScale;
                    }
                else
                    {
                        boardPos = 0;
                        flipping = false;
                    }
                }

            else if(boardPos == 0)
            {
                if(myScaleY <= 1.25f)
                    {
                        Vector3 newScale = new Vector3(1.25f, myScaleY ,1.25f);
                        myScaleY += 0.05f;
                        transform.localScale = newScale;
                    }
                else
                    {
                        boardPos = 1;
                        flipping = false;
                    }
            }
            else 
                flipping = false;
        }
    }

    // Update is called once per frame
    void Flip()
    {
       if(!flipping)
        flipping = true;
    }
}
