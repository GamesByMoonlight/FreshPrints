using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOptions : MonoBehaviour
{

    public int nutt;

    // Start is called before the first frame update
    void Start()
    {

        nutt = 5;


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelOptions()
    {

        LevelData data = SaveSystem.LoadLevels();

        nutt = data.NutsCollected[0]; ;


    }


}
