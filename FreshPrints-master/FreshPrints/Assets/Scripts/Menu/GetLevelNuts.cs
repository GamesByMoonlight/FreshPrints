using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLevelNuts : MonoBehaviour
{
    public Text TextNut;
    private int nut =0;
    public int LevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        nut =SaveSystem.GetNutByLevel(LevelNumber);
        TextNut.text = nut.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
