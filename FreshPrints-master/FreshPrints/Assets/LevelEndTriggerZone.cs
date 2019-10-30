using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelEndTriggerZone : MonoBehaviour
{
    int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        string levelName = SceneManager.GetActiveScene().name;
        char[] TheWorldLevel = { 'L', 'e', 'v', 'l' };
        try
        {
            levelNumber = int.Parse(levelName.TrimStart(TheWorldLevel));
        }
        catch (FormatException e)
        {
            Debug.Log("Level names must be formatted as Level##");
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var collectablesManager = GetComponentInParent<CollectablesManager>();

        // Logic for a level complete screen could go here

        if(col.GetComponent<PlayerControllerScript>())
        {
            SaveSystem.SaveLevelData(levelNumber, collectablesManager.CollectedAcorns);
            GameEventSystem.OnEndLevel(levelNumber, collectablesManager.CollectedAcorns);

            SceneManager.LoadScene("LevelSelectionScreen_JMiller");
        }
    }

}
