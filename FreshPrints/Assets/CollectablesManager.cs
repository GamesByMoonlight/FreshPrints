using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Manages the reporting of collected acorns to the UI
/// The reporting of the final score should happen here but it just doesn't yet
/// </summary>
public class CollectablesManager : MonoBehaviour
{
    JumpingGameCollectable[] Acorns;
    LevelUI UI;

    void Start()
    {
        UI = FindObjectOfType<LevelUI>();

        Acorns = FindObjectsOfType<JumpingGameCollectable>();
        Acorns = Acorns.OrderBy(x => x.transform.position.x).ToArray();
    }

    public void AcornCollected(JumpingGameCollectable collectedAcorn)
    {
        for (int i = 0; i <= Acorns.Length; i++)
        {
            if(Acorns[i] == collectedAcorn)
            {
                UI.CollectAcorn(i);
                break;
            }
        }
    }
}
