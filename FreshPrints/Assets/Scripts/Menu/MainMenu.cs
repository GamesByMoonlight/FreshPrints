﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {

        SceneManager.LoadScene("SampleScene");

       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }


    public void LevelsScene()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitGame()
    {
//        Application.Quit();

        Debug.Log("Quit Game");

    }


    public void LevelsScene(string level)
    {
        string lv = "Level" + level;
        SceneManager.LoadScene(lv);
    }






}
