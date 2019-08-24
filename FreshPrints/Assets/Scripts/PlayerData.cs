using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public int level;
    public int health;
    public float[] position;

    public int[] NutsCount;


    public PlayerData(Player player )
    {
        level = player.level;
        health = player.health;
        
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }


    public void UpdateNuts(int level, int nuts)
    {
        if (level < 1)
            return;
        level--;

        NutsCount[level] = nuts;


    }







}
