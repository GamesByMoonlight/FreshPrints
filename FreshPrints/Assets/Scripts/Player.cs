using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int level = 3;
    public int health = 100;

    // will also save the player postion... tranform...j


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position = new Vector3(0,0,0);
        position.x = data.position[0];
        position.y = data.position[1];
        position.x = data.position[2];
        transform.position = position;


    }





}
