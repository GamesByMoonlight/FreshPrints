using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour {

    private Text scoreText, goalText;
    public int currentScore, scoreToWin = 25;

    void Start()
    {

        // Go find the display for the player's score and goal score and create a reference
        Text[] childrenTextObjects;

        childrenTextObjects = GetComponentsInChildren<Text>();

        foreach(Text child in childrenTextObjects)
        {
            if(child.CompareTag("Player Score"))
            {
                scoreText = child;
            } else if(child.CompareTag("Goal Score"))
            {
                goalText = child;
            }
        }

        goalText.text = scoreToWin.ToString();

        UpdateDisplay();
    }

    void AddScore(int value)
    {
        currentScore += value;
        UpdateDisplay();
    }

    void ResetScore()
    {
        currentScore = 0;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if (scoreText)
        {
            scoreText.text = currentScore.ToString();
        }
        
    }

    
    #region Subscribe to events
    void OnEnable()
    {
        JumpingGameEventSystem.ScoreAdded += AddScore;
        JumpingGameEventSystem.LevelReset += ResetScore;
    }

    void OnDisable()
    {
        JumpingGameEventSystem.ScoreAdded -= AddScore;
        JumpingGameEventSystem.LevelReset -= ResetScore;
    }
    #endregion

}
