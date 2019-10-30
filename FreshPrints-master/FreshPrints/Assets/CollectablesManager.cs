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

    private int _collectedAcorns;
    public int CollectedAcorns {
        get
        {
            return _collectedAcorns;
        }
    }

    void Start()
    {
        UI = FindObjectOfType<LevelUI>();

        Acorns = FindObjectsOfType<JumpingGameCollectable>();
        Acorns = Acorns.OrderBy(x => x.transform.position.x).ToArray();

        _collectedAcorns = 0;
    }

    public void AcornCollected(JumpingGameCollectable collectedAcorn)
    {
        for (int i = 0; i <= Acorns.Length; i++)
        {
            if(Acorns[i] == collectedAcorn)
            {
                _collectedAcorns++; 
                UI.CollectAcorn(i);
                break;
            }
        }
    }

    void ResetNutCount()
    {
        _collectedAcorns = 0;
    }

    void OnEnable()
    {
        GameEventSystem.LevelReset += ResetNutCount;
    }

    void OnDisable()
    {
        GameEventSystem.LevelReset -= ResetNutCount;
    }
}
