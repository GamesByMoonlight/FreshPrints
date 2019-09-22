using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    private GameEventSystem instance;

    GameEventSystem()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }    
    }
        
    public delegate void AddScoreEventHandler(int value);
    public static event AddScoreEventHandler ScoreAdded;

    public delegate void ResetLevelEventHandler();
    public static event ResetLevelEventHandler LevelReset;

    public delegate void BeginPlayEventHandler();
    public static event BeginPlayEventHandler BeginPlay;

    public delegate void EndLevelEventHandler(int level, int acornCount);
    public static event EndLevelEventHandler EndLevel;


    void Start()
    {
        OnLevelReset();
        DontDestroyOnLoad(this);
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

    public static void OnEndLevel(int level, int acornCount)
    {
        // As of 9/22/2019 nothing is subscribed to this event, but leaving it in place just in case
        if (EndLevel != null)
        {
            EndLevel(level, acornCount);
        }
    }
}
