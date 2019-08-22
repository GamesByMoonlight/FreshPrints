using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGameCollectable : MonoBehaviour {

    
    private CollectAcorn acorn;

    void Start()
    {
        acorn = FindObjectOfType<CollectAcorn>();
    }

    public void OnCollected()
    {
        SpriteRenderer mySprite;
        CircleCollider2D myCollider;

        mySprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CircleCollider2D>();

        mySprite.enabled = false;
        myCollider.enabled = false;

        if (acorn)
            acorn.CollectableAnimation(transform.position);
    }
    
}
