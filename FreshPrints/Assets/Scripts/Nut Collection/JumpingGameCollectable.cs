using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGameCollectable : MonoBehaviour {

    private CollectAcorn acorn;
    private CollectablesManager collectablesManager;

    void Start()
    {
        acorn = FindObjectOfType<CollectAcorn>();
        collectablesManager = FindObjectOfType<CollectablesManager>();
    }

    public void OnCollected()
    {
        SpriteRenderer mySprite;
        CircleCollider2D myCollider;

        mySprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CircleCollider2D>();

        mySprite.enabled = false;
        myCollider.enabled = false;

        collectablesManager.AcornCollected(this);

        if (acorn)
            acorn.CollectableAnimation(transform.position);
    }
}
