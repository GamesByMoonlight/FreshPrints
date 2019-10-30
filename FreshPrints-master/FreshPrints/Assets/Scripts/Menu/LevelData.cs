using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelData
{
    public int[] NutsCollected;


    public LevelData()
    {
        Debug.Log("levelData");

        Debug.Log("leveldata1");

    }

    public LevelData(LevelOptions levelOptions)
    {

        NutsCollected[0] = levelOptions.nutt;
    }

    public LevelData(Player player)
    {
        player.level--;
        NutsCollected[player.level] = player.nuts;

    }

    public LevelData(int level, int TotalNuts)
    {
        //        NutsCollected[level] = TotalNuts;
        Debug.Log("levledata(1,40)");
        NutsCollected[0] = 2;
        NutsCollected[1] = 3;

    }

    public void UpdateNuts(int level, int TotalNuts)
    {
        if (level < 1)
        {
            return;
        }
        level--;
        NutsCollected[level] = TotalNuts;
    }


}

