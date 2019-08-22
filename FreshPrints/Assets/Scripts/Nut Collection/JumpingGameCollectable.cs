using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGameCollectable : MonoBehaviour {

    [SerializeField]
    public int Value;

    private CollectAcorn acorn;

    void Start()
    {
        acorn = FindObjectOfType<CollectAcorn>();
    }

    public void OnCollected()
    {
        MeshRenderer myMesh;
        SphereCollider myCollider;

        myMesh = GetComponent<MeshRenderer>();
        myCollider = GetComponent<SphereCollider>();

        myMesh.enabled = false;
        myCollider.enabled = false;

        acorn.CollectableAnimation(transform.position);
    }
    
}
