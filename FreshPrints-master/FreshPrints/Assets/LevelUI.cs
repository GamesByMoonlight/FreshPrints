using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    RawImage[] acornUIImages;
    int collectedAcornCount;

    // Start is called before the first frame update
    void Start()
    {
        acornUIImages = GetComponentsInChildren<RawImage>();

        acornUIImages.OrderBy(img => img.transform.position.x).ToArray();

        ClearCollected();
    }

    private void ClearCollected()
    {
        foreach (var image in acornUIImages)
        {
            image.enabled = false;
        }

        collectedAcornCount = 0;
    }

    public void CollectAcorn(int acornNumber)
    {
        if(acornNumber <= acornUIImages.Length && acornUIImages[acornNumber].enabled == false)
        {
            acornUIImages[acornNumber].enabled = true;
            collectedAcornCount++;
        }
        else
        {
            Debug.Log("Error trying to register acorn #" + acornNumber + " in CollectAcorn method");
        }
    }

    void OnEnable()
    {
        GameEventSystem.LevelReset += ClearCollected;
    }

    void OnDisable()
    {
        GameEventSystem.LevelReset -= ClearCollected;
    }
}
