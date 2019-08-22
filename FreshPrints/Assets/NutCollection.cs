using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCollection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        JumpingGameCollectable touchedAcorn = col.GetComponent<JumpingGameCollectable>();

        if (touchedAcorn)
        {
            touchedAcorn.OnCollected();
        }
    }
}
