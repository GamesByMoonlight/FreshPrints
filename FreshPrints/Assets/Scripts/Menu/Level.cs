using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    int[] nuttsCollected;

    Text[] textObjects;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevelData();

        FillMenu();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SaveLevel()
    //{
    //    SaveSystem.SaveLevelData(this);

    //}

    public void LoadLevelData()
    {

        Debug.Log("here1");

        LevelData data = SaveSystem.LoadLevels();


        int level = 0;
        foreach ( int nut in data.NutsCollected)
        {
            nuttsCollected[level] = nut;
            level++;
        }
      


    }

    public void FillMenu()
    {
        textObjects = GetComponents<Text>();

        Debug.Log("Here fill menu");

        foreach (Text text in textObjects)
        {

            string textName = text.name;
            int level = 0;
            foreach (int nutts in nuttsCollected)
            {
                level++;
                if (textName == level.ToString())
                {
                    text.text = nutts.ToString();
                    return;
                }
                else
                {
                    text.text = "0";
                }
            }




        }



    }


}
