using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGameEventSystem : MonoBehaviour
{
    public delegate void AddScoreEventHandler(int value);
    public static event AddScoreEventHandler ScoreAdded;

    public delegate void ResetLevelEventHandler();
    public static event ResetLevelEventHandler LevelReset;

    public delegate void BeginPlayEventHandler();
    public static event BeginPlayEventHandler BeginPlay;

    public delegate void PlayerFailureEventHandler();
    public static event BeginPlayEventHandler PlayerFail;

    public delegate void EndLevelEventHandler(bool didIWin);
    public static event EndLevelEventHandler EndLevel;


    void Start()
    {
        OnLevelReset();
    }

    public static void OnScoreAdded(int score)
    {
        if(ScoreAdded != null)
        {
            ScoreAdded(score);
        }
    }

    public static void OnLevelReset()
    {
        if(LevelReset != null)
        {
            LevelReset();
        }
    }

    public static void OnBeginPlay()
    {
        if(BeginPlay != null)
        {
            BeginPlay();
        }
    }

    public static void OnPlayerFail()
    {
        if(PlayerFail != null)
        {
            PlayerFail();
        }
    }

    public static void OnEndLevel(bool didIWin)
    {
        if(EndLevel != null)
        {
            EndLevel(didIWin);
        }
    }
}
