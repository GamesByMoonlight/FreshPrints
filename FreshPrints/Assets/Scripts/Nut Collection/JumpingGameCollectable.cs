using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGameCollectable : MonoBehaviour {

    [SerializeField]
    public int Value;

    private CollectGold gold;

    void Start()
    {
        gold = FindObjectOfType<CollectGold>();
    }

    public void OnCollected()
    {
        MeshRenderer myMesh;
        SphereCollider myCollider;

        myMesh = GetComponent<MeshRenderer>();
        myCollider = GetComponent<SphereCollider>();

        myMesh.enabled = false;
        myCollider.enabled = false;

        gold.CollectableAnimation(transform.position);
    }
    
}
