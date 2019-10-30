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
        RemoveAcorn();

        if (acorn)
            acorn.CollectableAnimation(transform.position);
    }

    private void RemoveAcorn()
    {
        CircleCollider2D myCollider;

        myCollider = GetComponent<CircleCollider2D>();
        myCollider.enabled = false;

        MeshRenderer[] meshes;
        meshes = GetComponentsInChildren<MeshRenderer>();

        foreach (var mesh in meshes)
        {
            mesh.enabled = false;
        }

        collectablesManager.AcornCollected(this);

    }

    private void AddAcorn()
    {
        CircleCollider2D myCollider;

        myCollider = GetComponent<CircleCollider2D>();
        myCollider.enabled = true;

        MeshRenderer[] meshes;
        meshes = GetComponentsInChildren<MeshRenderer>();

        foreach (var mesh in meshes)
        {
            mesh.enabled = true;
        }
    }
}
