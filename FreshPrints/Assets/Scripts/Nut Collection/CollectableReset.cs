using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class to take all childed objects and reset their colliders and meshes when JumpingGameEventSystem.LevelReset is called
public class CollectableReset : MonoBehaviour {
    

    void ResetCollectables()
    {
        foreach (Transform child in transform)
        {
            SphereCollider col = child.GetComponent<SphereCollider>();
            if (col)
            {
                col.enabled = true;
            }

            MeshRenderer mesh = child.GetComponent<MeshRenderer>();
            if (mesh)
            {
                mesh.enabled = true;
            }    
        }
    }

    #region Event System Subscribing
    void OnEnable()
    {
        JumpingGameEventSystem.LevelReset += ResetCollectables;
    }

    void OnDisable()
    {
        JumpingGameEventSystem.LevelReset -= ResetCollectables;
    }

    #endregion
}
